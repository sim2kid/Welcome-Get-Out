using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollController : MonoBehaviour
{
    [SerializeField]
    private GameObject Blurr;
    [SerializeField]
    private GameObject Rock;
    [SerializeField]
    private GameObject Paper;
    [SerializeField]
    private GameObject Scissors;

    public RollState rollState;

    private bool midRoll;
    // Start is called before the first frame update
    void Start()
    {
        setBlurr();
        midRoll = false;
    }

    private void turnAllOff() 
    {
        Blurr.SetActive(false);
        Rock.SetActive(false);
        Paper.SetActive(false);
        Scissors.SetActive(false);
    }

    public void setBlurr() 
    {
        turnAllOff();
        Blurr.SetActive(true);
        rollState = RollState.None;
    }

    public void Roll(int what) 
    {
        if(!midRoll)
            StartCoroutine(goRoll(what));
    }

    private IEnumerator goRoll(int what) 
    {
        midRoll = true;
        setBlurr();
        yield return new WaitForSeconds(2);
        SetThrow(what);
        midRoll = false;
    }

    public void setRock() 
    {
        turnAllOff();
        Rock.SetActive(true);
        rollState = RollState.Rock;
    }

    public void setPaper() 
    {
        turnAllOff();
        Paper.SetActive(true);
        rollState = RollState.Paper;
    }

    public void setScissors() 
    {
        turnAllOff();
        Scissors.SetActive(true);
        rollState = RollState.Scissors;
    }

    public void RollRandom() 
    {
        Roll(Random.Range(0, 3));
    }

    public void SetThrow(int thrown) 
    {
        switch (thrown)
        {
            case 0:
                setRock();
                break;
            case 1:
                setPaper();
                break;
            case 2:
                setScissors();
                break;
        }
    }
}

public enum RollState 
{
    None = -1,
    Rock = 0,
    Paper = 1,
    Scissors = 2
}