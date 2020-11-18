using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum state
{
    attack,circle,wait
}

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public int attack = 5;

    public Image circle;
    public boss boss;
    public control[] controls;
    public int[] timePoint;

    public state nowState = state.wait;
    public int nowWeapon = 0;

    private float epsilon = 0.1f;
    private int now = 0;

    private float timer = 0;
    private bool takeTime = false;

    private float circleTimer = 0;
    private float circleNeed = 2;

    private float inputTimer = 0;
    private float inputNeed = 0.3f;

    private AudioSource[] _audio;
    private Vector3 m_pos;
    private float lastRotate = 0;
    private float moveEpsilon = 30;

    private bool canInput = true;

    [HideInInspector]
    public float music = 0;
    [HideInInspector]
    public float SE = 0;

    private void Awake()
    {
        instance = this;
        music = PlayerPrefs.GetFloat("music");
        SE = PlayerPrefs.GetFloat("se");
        _audio = gameObject.GetComponents<AudioSource>();
        setMusicVolume(music);
        setSEVolume(SE);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            K2Games.ConfirmDialogueScreen.Instance.Show();
        }

        story();
        if(canInput)
            input();
    }

    public void story()
    {
        if (takeTime)
            timer += Time.deltaTime;
        if (Mathf.Abs(timer - timePoint[0]) < epsilon)
        {
            if (now == 0)
            {
                boss.canSpawn = false;
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + 2)) < epsilon)
        {
            if (now == 1)
            {
                changeState(state.wait);
                K2Games.NewsTicker.Instance.LoadNextMessage();
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + 4)) < epsilon)
        {
            if (now == 2)
            {
                K2Games.NewsTicker.Instance.LoadNextMessage();
                now++;
            }

        }
        else if (Mathf.Abs(timer - (timePoint[0] + 6)) < epsilon)
        {
            if (now == 3)
            {
                K2Games.NewsTicker.Instance.LoadNextMessage();
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + 8)) < epsilon)
        {
            if (now == 4)
            {
                K2Games.NewsTicker.Instance.LoadNextMessage();
                takeTime = false;
                boss.changeCanHit(true);
                changeState(state.circle);
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + 18)) < epsilon)
        {
            if (now == 5)
            {
                controls[nowWeapon].stop();
                nowWeapon++;
                K2Games.NewsTicker.Instance.LoadNextMessage();
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + 20)) < epsilon)
        {
            if (now == 6)
            {
                boss.changeCanHit(false);
                K2Games.NewsTicker.Instance.LoadNextMessage();
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + 22)) < epsilon)
        {
            if (now == 7)
            {
                K2Games.NewsTicker.Instance.LoadNextMessage();
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + 24)) < epsilon)
        {
            if (now == 8)
            {
                boss.canSpawn = true;
                changeState(state.attack);
                takeTime = true;
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0]+ timePoint[1]+24)) < epsilon)
        {
            if (now == 9)
            {
                boss.canSpawn = false;
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + timePoint[1] + 26)) < epsilon)
        {
            if (now == 10)
            {
                changeState(state.wait);
                K2Games.NewsTicker.Instance.LoadNextMessage();
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + timePoint[1] + 28)) < epsilon)
        {
            if (now == 11)
            {
                K2Games.NewsTicker.Instance.LoadNextMessage();
                takeTime = false;
                boss.changeCanHit(true);
                changeState(state.circle);
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + timePoint[1] + 38)) < epsilon)
        {
            if (now == 12)
            {
                controls[nowWeapon].stop();
                nowWeapon++;
                K2Games.NewsTicker.Instance.LoadNextMessage();
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + timePoint[1] + 40)) < epsilon)
        {
            if (now == 13)
            {
                boss.changeCanHit(false);
                K2Games.NewsTicker.Instance.LoadNextMessage();
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + timePoint[1] + 42)) < epsilon)
        {
            if (now == 14)
            {
                boss.enemySpeed *= 2.0f;
                boss.canSpawn = true;
                changeState(state.attack);
                takeTime = true;
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + timePoint[1] + timePoint[2] + 42)) < epsilon)
        {
            if (now == 15)
            {
                boss.canSpawn = false;
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + timePoint[1] + timePoint[2] + 44)) < epsilon)
        {
            if (now == 16)
            {
                changeState(state.wait);
                K2Games.NewsTicker.Instance.LoadNextMessage();
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + timePoint[1] + timePoint[2] + 46)) < epsilon)
        {
            if (now == 17)
            {
                K2Games.NewsTicker.Instance.LoadNextMessage();
                takeTime = false;
                boss.changeCanHit(true);
                changeState(state.circle);
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + timePoint[1] + timePoint[2] + 56)) < epsilon)
        {
            if (now == 18)
            {
                controls[nowWeapon].stop();
                nowWeapon++;
                stopSE();
                boss.die();
                K2Games.NewsTicker.Instance.LoadNextMessage();
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + timePoint[1] + timePoint[2] + 58)) < epsilon)
        {
            if (now == 19)
            {
                K2Games.NewsTicker.Instance.LoadNextMessage();
                now++;
            }
        }
        else if (Mathf.Abs(timer - (timePoint[0] + timePoint[1] + timePoint[2] + 60)) < epsilon)
        {
            if (now == 20)
            {
                K2Games.MainMenu.Instance.CloseUI();
                K2Games.BackgroundDetailsScreen.Instance.Hide();
                K2Games.HUD.Instance.Show();
                now++;
            }
        }
    }

    public void gameStart()
    {
        StartCoroutine(start());
    }

    IEnumerator start()
    {
        yield return new WaitForSeconds(1f);
        K2Games.NewsTicker.Instance.LoadNextMessage();
        yield return new WaitForSeconds(2f);
        K2Games.NewsTicker.Instance.LoadNextMessage();
        yield return new WaitForSeconds(2f);
        K2Games.NewsTicker.Instance.LoadNextMessage();
        yield return new WaitForSeconds(2f);
        K2Games.NewsTicker.Instance.LoadNextMessage();
        yield return new WaitForSeconds(2f);
        boss.canSpawn = true;
        changeState(state.attack);
        playMusic(true);
        takeTime = true;
    }

    public void changeState(state s)
    {
        nowState = s;
        if (s == state.circle)
        {
            circle.gameObject.SetActive(true);
        }
        else
        {
            circle.gameObject.SetActive(false);
        }
    }

    public void input()
    {
        inputTimer += Time.deltaTime;

        if (nowState == state.attack)
        {
#if UNITY_STANDALONE_WIN
            //0123，上下左右，4567从右上开始顺时针
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                controls[nowWeapon].attack(0);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                controls[nowWeapon].attack(1);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                controls[nowWeapon].attack(2);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                controls[nowWeapon].attack(3);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                controls[nowWeapon].attack(4);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                controls[nowWeapon].attack(5);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                controls[nowWeapon].attack(6);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                controls[nowWeapon].attack(7);
            }
#endif

#if UNITY_ANDROID
            if (inputTimer > inputNeed)
            {
                if (Input.touchCount == 1)
                {
                    Vector3 pos = Input.GetTouch(0).position;
                    pos.x -= Screen.width / 2; pos.y -= Screen.height / 2;

                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        m_pos = pos;
                    }

                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        Vector3 move = pos - m_pos;
                        //0123，上下左右，4567从右上开始顺时针
                        if (move.y > moveEpsilon)
                        {
                            if (move.x > moveEpsilon)
                            {
                                controls[nowWeapon].attack(6);
                                inputTimer = 0;
                            }
                            else if (move.x < -moveEpsilon)
                            {
                                controls[nowWeapon].attack(5);
                                inputTimer = 0;
                            }
                            else if (move.y > moveEpsilon*1.5f)
                            {
                                controls[nowWeapon].attack(1);
                                inputTimer = 0;
                            }
                        }
                        else if (move.y < -moveEpsilon)
                        {
                            if (move.x > moveEpsilon)
                            {
                                controls[nowWeapon].attack(7);
                                inputTimer = 0;
                            }
                            else if (move.x < -moveEpsilon)
                            {
                                controls[nowWeapon].attack(4);
                                inputTimer = 0;
                            }
                            else if (move.y < -moveEpsilon * 1.5f)
                            {
                                controls[nowWeapon].attack(0);
                                inputTimer = 0;
                            }
                        }
                        else
                        {
                            if (move.x > moveEpsilon * 1.5f)
                            {
                                controls[nowWeapon].attack(2);
                                inputTimer = 0;
                            }
                            else if (move.x < -moveEpsilon * 1.5f)
                            {
                                controls[nowWeapon].attack(3);
                                inputTimer = 0;
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
#endif
        }
        else if (nowState == state.circle)
        {
#if UNITY_STANDALONE_WIN
            if (Input.GetKey(KeyCode.Z))
            {
                circleTimer += Time.deltaTime;
            }
            else
            {
                if (circleTimer > Time.deltaTime * 2)
                    circleTimer -= Time.deltaTime * 2;
                else
                    circleTimer = 0;
            }
#endif

#if UNITY_ANDROID
            if (Input.touchCount == 1)
            {
                Vector3 pos = Input.GetTouch(0).position;
                pos.x -= Screen.width / 2; pos.y -= Screen.height / 2;

                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    m_pos = pos;
                }

                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Vector3 currentPos = Vector3.Cross(pos, m_pos);
                    if (lastRotate != 0)
                    {
                        if(currentPos.z * lastRotate>0)
                            circleTimer += Time.deltaTime;
                    }

                    m_pos = pos;
                    lastRotate = currentPos.z;
                }
            }
            else
            {
                if (circleTimer > Time.deltaTime * 2)
                    circleTimer -= Time.deltaTime * 2;
                else
                    circleTimer = 0;
            }
#endif
            circle.fillAmount = circleTimer / circleNeed;
            if (circleTimer >= circleNeed)
            {
                circleTimer = 0;
                controls[nowWeapon].circle();
                circle.gameObject.SetActive(false);
                changeState(state.wait);
                takeTime = true;
            }
        }
    }

    public void pause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
            canInput = false;
        }
        else
        {
            Time.timeScale = 1.0f;
            canInput = true;
        }
    }

    public void exit()
    {
        Application.Quit();
    }

    public void setMusicVolume(float v)
    {
        _audio[0].volume = v/100;
        music = v;
    }

    public void setSEVolume(float v)
    {
        for(int i=1;i<_audio.Length;i++)
            _audio[i].volume = v/100;
        SE = v;
    }

    public void playMusic(bool a)
    {
        if(a)
            _audio[0].Play();
        else
            _audio[0].Stop();
    }

    public void playSE(AudioClip a)
    {
        for (int i = 1; i < _audio.Length; i++)
            if (!_audio[i].isPlaying)
            {
                _audio[i].clip = a;
                _audio[i].Play();
                break;
            }
    }

    public void stopSE()
    {
        for (int i = 1; i < _audio.Length; i++)
        {
            _audio[i].Stop();
        }
    }
}
