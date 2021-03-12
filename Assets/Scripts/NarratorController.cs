using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private new AudioController audio;
    protected float recordedTime;
    protected bool triggered;
    private bool lastPlaying;

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
                PlayLine();
    }

    // Update is called once per frame
    private void Update()
    {
        if (narration != null) {
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
                        if (!audio.IsPlaying())
                        {
                            if (lastPlaying != audio.IsPlaying())
                            {
                                triggered = false;
                                recordedTime = Time.time;
                            }
                            if (OnTrigger(narration.voiceLines[index].triggerVariable) || triggered)
                                NextLine();
                        }
                        lastPlaying = audio.IsPlaying();
                        break;
                    case LineTriggers.OnEnd:
                        if(!audio.IsPlaying())
                            NextLine();
                        break;
                    case LineTriggers.OnWait:
                        if (OnWait(narration.voiceLines[index].triggerVariable))
                            NextLine();
                        break;
                    case LineTriggers.OnEndWait:
                        if (!audio.IsPlaying()) 
                        {
                            if (lastPlaying != audio.IsPlaying()) 
                            {
                                recordedTime = Time.time;
                            }
                            if (OnWait(narration.voiceLines[index].triggerVariable))
                                NextLine();
                        }
                        lastPlaying = audio.IsPlaying();
                        break;
                    default:
                        // Acts like None. Nothing will happen
                        break;
                }
            }
        }
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

    protected void NextLine() 
    {
        if(narration.voiceLines[index].runWhenTriggered != null)
            narration.voiceLines[index].runWhenTriggered.Invoke();
        index = narration.voiceLines[index].nextIndex;
        PlayLine();
    }

    private void PlayLine() 
    {
        if (narration.voiceLines[index].audioClip != null)
            audio.InterruptAudio(narration.voiceLines[index].audioClip);
        if (narration.voiceLines[index].textLine != null) { }
        // narration.voiceLines[index].textLine
        // TODO Pass to closed captions script
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