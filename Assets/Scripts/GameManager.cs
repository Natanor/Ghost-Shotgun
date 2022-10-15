using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int bullets;
    public AudioClip shotSound;
    private AudioSource cameraAudioSource;
    private FollowPlayer followPlayerScript;
    private int maxBullets;
    public Image[] bulletIcons;
    public string nextScene;

    public Sprite emptyBulletSprite;
    public Sprite fullBulletSprite;

    public float winSlowDown;
    public float winZoom;
    public float winTime;
    private bool won;

    // Start is called before the first frame update
    void Start()
    {
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        followPlayerScript = GameObject.Find("Main Camera").GetComponent<FollowPlayer>();

        maxBullets = bulletIcons.Length;
        ResetBulletCount();
        won = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Debug Reset"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }


    private void UpdateBulletCount(int count)
    {
        bullets = count;

        for (int i = 0; i < bulletIcons.Length; i++)
        {
            bulletIcons[i].sprite = i < bullets ? fullBulletSprite : emptyBulletSprite;
        }
          
    }

    public void AddBullets(int bulletsToAdd)
    {
        UpdateBulletCount(Math.Min(bullets + bulletsToAdd, maxBullets));
    }

    public void ResetBulletCount()
    {
        UpdateBulletCount(maxBullets);
    }

    public bool TryLoseBullet()
    {
        if (bullets > 0)
        {
            UpdateBulletCount(bullets - 1);
            return true;
        }
        return false;
    }
    
    public void PlayShotSound()
    {
        cameraAudioSource.PlayOneShot(shotSound, 0.3f);
    }

    public void WinLevel()
    {
        if (!won)
        {
            StartCoroutine(WinEffect());
            won = true;
        }
    }

    IEnumerator WinEffect()
    {
        Time.timeScale = winSlowDown;
        followPlayerScript.ChangeOrthSize(winZoom);
        followPlayerScript.offset = Vector2.zero;

        yield return new WaitForSeconds(winTime);
        Time.timeScale = 1;

        if (nextScene == null || nextScene.Length == 0)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
