**인게임 씬이 인게임 ui오브젝트를 가지고있도록 하여 필요시 호출하여 생성 및 파괴하려고 함
- 하지만 접근이 쉽지 않았고 tag나 싱글톤 등을 사용하기에도 방식이 좋지 않았음
- 인게임 씬에서 ui를 관리하는 것이 아닌 ui들을 따로 프리펩화 하여 가져오도록 방향 전환

#### 미니게임을 관리하는 개별 클래스가 인게임 ui를 관리하는 부모 클래스 하나를 상속받도록 하여 공용으로 쓰도록 하기
1. ui오브젝트와 프리펩 오브젝트로 변수필드 설정
2. 싱글톤화 되어있는 오브젝트에게 프리펩을 인스펙터 창에서 달아주기
3. 그 오브젝트 들을 awake 함수에서 찾고 캐싱해두기
4. 함수 하나를 실행하여 ui들을 생성하여 쓸 수 있도록 하기
5. 게임 클리어, 실패 함수도 넣어두고 공용으로 돌려쓰도록 하기

```
public class MiniGameSetting : MonoBehaviour
{
    //ui오브젝트를 인스펙터 창에서 받아온 뒤 프리펩 오브젝트로 따로 생성
    protected GameObject m_missionUI;
    protected GameObject m_timeUI;
    protected GameObject m_countUI;
    protected GameObject m_clearUI;
    protected GameObject m_failUI;
    protected GameObject m_missionPrefab;
    protected GameObject m_timePrefab;
    protected GameObject m_countPrefab;
    protected GameObject m_clearPrefab;
    protected GameObject m_failPrefab;

    private void Awake()
    {
        m_missionUI = MiniGameManager.Instance.InGameUIs[0];
        m_timeUI = MiniGameManager.Instance.InGameUIs[1];
        m_countUI = MiniGameManager.Instance.InGameUIs[2];
        m_clearUI = MiniGameManager.Instance.InGameUIs[3];
        m_failUI = MiniGameManager.Instance.InGameUIs[4];
    }

    protected void StartSetting()
    {
        //미니게임 오브젝트 하위에 생성되도록 하기
        m_missionPrefab = Instantiate(m_missionUI, transform.position, Quaternion.identity, transform);
        m_timePrefab = Instantiate(m_timeUI, transform.position, Quaternion.identity, transform);
        m_countPrefab = Instantiate(m_countUI, transform.position, Quaternion.identity, transform);
        m_clearPrefab = Instantiate(m_clearUI, transform.position, Quaternion.identity, transform);
        m_failPrefab = Instantiate(m_failUI, transform.position, Quaternion.identity, transform);

        //초기에는 false로 설정되도록 
        m_missionPrefab.SetActive(false);
        m_timePrefab.SetActive(false);
        m_countPrefab.SetActive(false);
        m_clearPrefab.SetActive(false);
        m_failPrefab.SetActive(false);
    }

    //게임 클리어, 실패 함수
    protected void GameClear()
    {
        MiniGameManager.Instance.GameClear();
    }

    protected void GameFail()
    {
        MiniGameManager.Instance.GameFail();
    }


}
```