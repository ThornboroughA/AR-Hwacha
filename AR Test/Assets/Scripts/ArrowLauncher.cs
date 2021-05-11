using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour
{

    

    [SerializeField] private GameObject[] arrows = null;
    [SerializeField] private GameObject[] arrowFire = null;
    [SerializeField] private GameObject[] arrowSmoke = null;

    [SerializeField] private Animator arrowAnim = null;

    [SerializeField] private AudioClip[] rocketSounds = null;
    private AudioSource audioSource;

    private Coroutine firingRoutine;
    private bool coroutineActive = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            TryActivate();
        }
    }

    public void TryActivate()
    {
        print("try");
        if (TrackingTest.instance.modelActive == true)
            {
                //print("register input");
                ActivateArrows();
            }
            else
            {
                //print("model inactive");
            }
        
    }


    public void ActivateArrows()
    {
        firingRoutine = StartCoroutine(LightArrows());
    }

    //animation sequence
    private IEnumerator LightArrows()
    {
        coroutineActive = true;

        ToggleFire();
        yield return new WaitForSeconds(1f);
        ToggleSmoke();
        StartAnimation();

        yield return new WaitForSeconds(5f);
        ToggleArrows();
        ToggleFire();
        ToggleSmoke();
        yield return new WaitForSeconds(2f);
        ToggleArrows();
        ResetAnimation();

        coroutineActive = false;
    }

    private IEnumerator RocketSounds()
    {
        yield return new WaitForSeconds(1.3f);

        int count = 10;

        while (count > 0)
        {
            print("fire sound");
            int ran = Random.Range(0, rocketSounds.Length);
            audioSource.PlayOneShot(rocketSounds[ran]);
            count--;
            yield return new WaitForSeconds(Random.Range(0.08f, 0.2f));
        }
    }

    private void StartAnimation()
    {
        StartCoroutine(RocketSounds());
        arrowAnim.SetInteger("arrowState", 1);
    }
    private void ResetAnimation()
    {
        arrowAnim.SetInteger("arrowState", 0);
    }


    //object toggles
    private void ToggleArrows()
    {
        foreach (GameObject arrow in arrows)
        {
            if (arrow.activeSelf == true)
            {
                arrow.SetActive(false);
            } else
            {
                arrow.SetActive(true);
            }
        }
    }
    public void ToggleFire()
    {
        foreach (GameObject fire in arrowFire)
        {
            if (fire.activeSelf == true)
            {
                fire.SetActive(false);
            }else
            {
                fire.SetActive(true);
            }
        }
    }
    public void ToggleSmoke()
    {
        foreach (GameObject smoke in arrowSmoke)
        {
            if (smoke.activeSelf == true)
            {
                smoke.SetActive(false);
            } else
            {
                smoke.SetActive(true);
            }
        }
    }

}
