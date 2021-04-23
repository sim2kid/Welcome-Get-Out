using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static DialogueTree;

[RequireComponent(typeof(AudioController))]
public class NarratorController : MonoBehaviour, INarrator
{
    [SerializeField]
    private DialogueTree narration;
    [SerializeField]
    private int index = 0;
    [SerializeField]
    private bool playOnStart = true;
    [SerializeField]
    SubtitleController subs;

    private new AudioController audio;
    protected float recordedTime;
    protected bool triggered;
    private UnityEvent triggerCallback;
    private bool lastPlaying;
    private float subTime;

    private float timePerCharacter = 0.1f;

    private bool started = false;

    private void OnEnable()
    {
        audio = GetComponent<AudioController>();
    }

    private void Start()
    {
        triggered = false;
        // If everything is set up, We'll play the first audio line
        if (narration != null && playOnStart)
            if (narration.voiceLines.Count > index && index >= 0)
            {
                Invoke("PlayLine", 1);
            }
    }

    // Update is called once per frame
    private void Update()
    {
        if (narration != null && started) {
            //Make sure the index is inbounds
            if (narration.voiceLines.Count > index && index >= 0) {
                //Trigger listeners
                switch (narration.voiceLines[index].trigger) 
                {
                    case LineTriggers.None:
                        //End of script. nothing will happen
                        break;
                    case LineTriggers.OnTrigger:
                        if(OnTrigger(narration.voiceLines[index].triggerVariable) || triggered)
                            NextLine();
                        break;
                    case LineTriggers.OnEndTrigger:
                        if (!IsTalking())
                        {
                            if (lastPlaying != IsTalking())
                            {
                                triggered = false;
                                recordedTime = Time.time;
                            }
                            if (OnTrigger(narration.voiceLines[index].triggerVariable) || triggered)
                            {
                                NextLine();
                                if (triggerCallback != null)
                                {
                                    triggerCallback.Invoke();
                                    triggerCallback = null;
                                }
                            }
                        }
                        lastPlaying = IsTalking();
                        break;
                    case LineTriggers.OnEnd:
                        if(!IsTalking())
                            NextLine();
                        break;
                    case LineTriggers.OnWait:
                        if (OnWait(narration.voiceLines[index].triggerVariable))
                            NextLine();
                        break;
                    case LineTriggers.OnEndWait:
                        if (!IsTalking()) 
                        {
                            if (lastPlaying != IsTalking()) 
                            {
                                recordedTime = Time.time;
                            }
                            if (OnWait(narration.voiceLines[index].triggerVariable))
                                NextLine();
                        }
                        lastPlaying = IsTalking();
                        break;
                    default:
                        // Acts like None. Nothing will happen
                        break;
                }
            }
        }
        if (!IsTalking())
            subs.Hide();
        if (subTime > 0)
            subTime -= Time.deltaTime;
        Debug.Log(subTime);
    }
    public bool IsTalking()
    {
        if (narration.voiceLines[index].audioClip != null) 
        {
            return audio.IsPlaying();
        }
        else 
        {
            return subTime > 0;
        }
    }
    public int atIndex()
    {
        return index;
    }
    public bool IsOver() 
    {
        return narration.voiceLines[index].trigger == LineTriggers.None;
    }

    private bool OnWait(int timeSeconds) 
    {
        return recordedTime + timeSeconds <= Time.time;
    }

    protected virtual bool OnTrigger(int triggerVar) 
    {
        return false;
        // Subclasses may extend this, but it will do nothing by default
    }

    public void Trigger() 
    {
        triggered = true;
    }

    public void JumpToLine(int lineIndex) 
    {
        NextLine(lineIndex);
    }

    public void Trigger(UnityEvent callback)
    {
        triggerCallback = callback;
        triggered = true;
    }

    protected void NextLine() 
    {
        NextLine(narration.voiceLines[index].nextIndex);
    }

    protected void NextLine(int nextIndex)
    {
        index = nextIndex;
        PlayLine();
    }

    private void PlayLine() 
    {
        started = true;
        subTime = 0;
        if (narration.voiceLines[index].audioClip != null)
            audio.InterruptAudio(narration.voiceLines[index].audioClip);
        else if (narration.voiceLines[index].textLine != null)
            subTime = narration.voiceLines[index].textLine.Length * timePerCharacter + 1f;
        if (narration.voiceLines[index].textLine != null)
        {
            subs.Show();
            subs.SetText(narration.voiceLines[index].textLine);
        }
        recordedTime = Time.time;
        triggered = false;
    }

    public void NewNarration(DialogueTree dialogue, int startAt) 
    {
        narration = dialogue;
        index = startAt;
        PlayLine();
    }
}