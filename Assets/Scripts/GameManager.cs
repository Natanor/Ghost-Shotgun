using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int bullets;
    public TextMeshProUGUI bulletText;
    public AudioClip shotSound;
    private AudioSource cameraAudioSource;
    private int maxBullets;
    public GameObject[] bulletIcons;


    // Start is called before the first frame update
    void Start()
    {
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        maxBullets = bulletIcons.Length;
        ResetBulletCount();

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

        for (int i=0; i < bulletIcons.Length; i++)
        {

            bulletIcons[i].SetActive(i < bullets);
        }
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
}
