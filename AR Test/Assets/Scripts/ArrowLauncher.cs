using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour
{

    [SerializeField] private GameObject[] arrows = null;
    [SerializeField] private GameObject[] arrowFire = null;
    [SerializeField] private GameObject[] arrowSmoke = null;

    [SerializeField] private Animator arrowAnim = null;

    private Coroutine firingRoutine;
    private bool coroutineActive = false;



    private void Update()
    {

      if (Input.GetKeyDown(KeyCode.Space))
        {
            if (TrackingTest.instance.modelActive == true)
            {
                print("register input");
                ActivateArrows();
            }
            else
            {
                print("model inactive");
            }
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

    private void StartAnimation()
    {
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
