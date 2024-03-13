using System;
using System.Collections.Generic;
using System.Management.Instrumentation;
using System.Security.Cryptography.X509Certificates;
using static BlackJack.BlackJackGame;

namespace BlackJack
{
    internal class BlackJackGame
    {
        public enum Suit {  Hearts, Diamonds, Clubs, Spades}        //문양종류 열거
        public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace}        //숫자종류 열거, 2부터 14까지


        static void Main(string[] args)     //메인함수
        {
            Blackjack game = new Blackjack();       //블랙젝 게임 생성
            game.PlayGame();        //게임시작 함수 호출
        }

        public class Card       //카드 한 장을 표현하는 클래스
        {
            public Suit Suit { get; private set; }      //카드의 무늬를 나타내는 변수 / 읽기 전용 프로퍼티

            public Rank Rank { get; private set; }      //카드의 숫자를 나타내는 변수 / 읽기 전용 프로퍼티

            public Card(Suit s, Rank r)                 //객체 생성자, 무늬와 숫자 속성을 가진 객체 생성
            {
                Suit = s;
                Rank = r;
            }


            public int GetValue()       //카드 하나의 점수를 반환해주는 함수
            {
                if ((int)Rank <= 10)        
                {
                    return (int)Rank;       //카드가 10보다 작거나 같으면 Rank 값을 int로 변환하여 반환
                }
                else if ((int)Rank <= 13)
                {
                    return 10;              //카드가 10 이상 13 이하이면 10을 반환 (J, Q, K)
                }
                else
                {
                    return 11;              //그 외 경우에는 11을 반환 (ACE를 11로 사용하는 경우, Enum 에서 에이스는 14이기 때문에 가능)
                }
            }

            public override string ToString()       //카드의 무늬와 숫자를 문자열로 반환하는 함수, 오버라이딩 함수
            {
                return $"{Rank} Of {Suit}";         
            }            
            
        }

        public class Deck       //카드 덱을 표현하는 클래스
        {
            private List<Card> cards;       //빈 리스트 생성

            public Deck()       //덱 생성
            {
                cards = new List<Card>();       //덱에 새로운 카드 리스트 생성

                foreach (Suit s in Enum.GetValues(typeof(Suit)))        // Enum 에서 Suit데이터를 가져온 후  s에 대입
                {
                    foreach (Rank r in Enum.GetValues(typeof(Rank)))        //Enum 에서 Rank데이터를 가져온 후  r에 대입
                    {
                        cards.Add(new Card(s, r));      //리스트에 (s,r) 데이터를 가진 카드 하나 생성
                    }

                 }
                Shuffle();      //카드 섞어주는 함수 생성

            }

            public void Shuffle()       //덱을 섞어주는 함수
            {
                Random rand = new Random();     //랜덤값 생성
                
                for (int i = 0; i < cards.Count; i++)       //카드 리스트의 수만큼 반복
                {
                    int j = rand.Next(i, cards.Count);      // (i ~ 카드 수 )사이의 랜덤한 값을 j에 대입 
                    Card temp = cards[i];                   // cards[i] 의 값과 cards[j] 의 값을 바꿔줌
                    cards[i] = cards[j];
                    cards[j] = temp;    
                }
            }

            public Card DrawCard()      //카드 한 장을 뽑는 함수
            {
                Card card = cards[0];       //리스트 0번째 카드 데이터 호출하여 card에 대입
                cards.RemoveAt(0);          //리스트의 0번째 데이터 삭제
                return card;                //card 데이터값 반환
            }

        }

        public class Hand        //플래이어의 패를 나타내는 클래스
        {
            private List<Card> cards;       //패를 나타내는 카드 리스트 선언

            public Hand()       //핸드 클래스 객체 생성자
            {
                cards = new List<Card>();       //핸드 객체에 새로운 카드 리스트 cards생성 (핸드 객체의 속성)
            }

            public void AddCard(Card card)      //핸드에 카드를 추가해주는 함수
            {
                cards.Add(card);        //카드 리스트에 새로운 카드 데이터 추가
            }

            public int GetTotalValue()      //패에 들어있는 카드들의 총 점을 계산해주는 함수
            {
                int total = 0;
                int aceCount = 0;

                foreach(Card card in cards)     //패의 카드 데이터 수 만큼 반복
                {
                    if (card.Rank == Rank.Ace)      //랭크의 값이 Ace 인 경우 카운트 1개 추가
                    {
                        aceCount++;                 
                    }
                    total += card.GetValue();       //total 값에 카드 값 추가
                }

                while (total > 21 && aceCount > 0)      //전체 값이 21을 넘고 ace 가 있는 경우 반복
                {
                    total -= 10;        //토탈의 전체 값을 10 감소하고
                    aceCount--;         //ace 카운트 1개 감소
                }
                return total;           //전체 값 반환

            }

        }

        public class Player     //플래이어를 나타내는 클래스
        {
            public Hand Hand { get; private set; }      //읽기 전용으로 hand 클래스의 새로운 hand 선언

            public Player()     //플래이어 클래스 객체 생성자
            {
                Hand = new Hand();      // 새로운 hand 생성 (플래이어 객체의 속성)
            }

            public Card DrawCardFromDeck(Deck deck)     //덱으로 부터 카드를 뽑는 함수
            {
                Card drawnCard = deck.DrawCard();       //덱으로 부터 드로우카드 함수를 호출한 후 반환값을 drawnCard 에 대입
                Hand.AddCard(drawnCard);                //핸드 리스트에 뽑은 카드의 데이터 추가
                return drawnCard;                       //뽑은 카드 데이터값 반환
            }
        }

        public class Dealer : Player        //딜러를 나타내는 함수
        {

            public void KeepDrawingCards(Deck deck)     //덱으로 부터 카드를 계속 뽑는 함수
            {
                while (Hand.GetTotalValue() < 17)       //핸드의 전체 값이 17보다 작으면 계속 반복
                {
                    Card drawnCard = DrawCardFromDeck(deck);        //덱으로 부터 카드를 뽑은 후 데이터를 drawn 카드에 대입
                    Console.WriteLine($"딜러는 '{drawnCard}'을(를) 뽑았습니다. 현재 총합은 {Hand.GetTotalValue()}점 입니다.");     //딜러가 뽑은 카드 정보 및 총점 출력  

                }
            }
        }

        public class Blackjack      //블랙젝 게임 클래스
        {
            private Player player;      //필드에 플레이어, 딜러, 덱 변수 선언
            private Dealer dealer;
            private Deck deck;

            public void PlayGame()      //게임 진행 함수 
            {
                deck = new Deck();      //새로운 덱 생성
                player = new Player();      //새로운 플레이어 생성
                dealer = new Dealer();      //새로운 딜러 생성

                for (int i = 0; i < 2; i++)     
                {
                    player.DrawCardFromDeck(deck);      //플레이어와 딜러 2장씩 카드 뽑기
                    dealer.DrawCardFromDeck(deck);

                }

                //게임 시작과 플레이어와 딜러가 뽑은 2장의 카드 합 출력
                Console.WriteLine("게임을 시작합니다!");
                Console.WriteLine($"플레이어의 초기 카드 합 : {player.Hand.GetTotalValue()}");
                Console.WriteLine($"딜러의 초기 카드 합 : {dealer.Hand.GetTotalValue()}");


                //플레이어 차례 시작, 21점이 넘지 않는 동안 계속 진행 가능
                while (player.Hand.GetTotalValue() < 21)        //플레이어의 핸드 카드의 총합이 21보다 작으면 반복
                {
                    Console.WriteLine("카드를 더 뽑으시겠습니까? (y/n): ");        
                    string input = Console.ReadLine();      //입력키를 받아 input에 저장

                    if(input.ToLower() == "y")      //input을 소문자로 변환한 값이 y인 경우 
                    {
                        Card drawnCard = player.DrawCardFromDeck(deck);     //덱에서 카드를 한장 뽑은 후 drawnCard에 값 저장
                        Console.WriteLine($"'{drawnCard}'을(를) 뽑았습니다. 현재 총합은 {player.Hand.GetTotalValue()}점 입니다.");                   
                    }
                    else
                    {
                        break;      //y가 아닌 경우 while문 멈춤
                    }
                }

                //딜러 카드뽑기 진행, 총합이 17점이 넘을 때 까지 카드를 반복해서 뽑음
                Console.WriteLine("딜러의 차례입니다.");
                dealer.KeepDrawingCards(deck);
                Console.WriteLine($"딜러의 총합은 {dealer.Hand.GetTotalValue()}점 입니다.");

                //딜러와 플레이어의 점수 총 합을 비교하여 승자 판정
                if (player.Hand.GetTotalValue() > 21)       //플레이어 카드 합 21 초과인 경우
                {
                    Console.WriteLine("플레이어의 카드 합이 21점을 초과했습니다. 딜러의 승리입니다.");                   
                }
                else if(dealer.Hand.GetTotalValue() > 21)       //딜러 카드 합 21 초과인 경우
                {
                    Console.WriteLine("딜러의 카드 합이 21점을 초과했습니다. 플레이어의 승리입니다.");
                }
                else if (player.Hand.GetTotalValue() > dealer.Hand.GetTotalValue())     //플레이어의 카드 합이 더 높은 경우
                {
                    Console.WriteLine("플레이어의 카드 합이 더 높습니다. 플레이어의 승리입니다");
                }
                else if (player.Hand.GetTotalValue() < dealer.Hand.GetTotalValue())     //딜러의 카드 합이 더 높은 경우
                {
                    Console.WriteLine("딜러의 카드 합이 더 높습니다. 딜러의 승리입니다");
                }
                else
                {
                    Console.WriteLine("무승부 입니다");
                }
            }

        }

    }
}
