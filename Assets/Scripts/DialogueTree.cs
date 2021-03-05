using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(order = 0, fileName = "Dialogue", menuName = "Dialogue Tree")]
public class DialogueTree : ScriptableObject
{
    public List<VoiceLine> voiceLines;

    [System.Serializable]
    public class VoiceLine 
    {
        [SerializeField]
        private int m_NextIndex;

        [SerializeField]
        private string m_TextLine;
        [SerializeField]
        private AudioClip m_AudioClip;

        [SerializeField]
        private UnityEvent m_RunWhenTriggered;

        [SerializeField]
        private LineTriggers m_Trigger;
        [SerializeField]
        private int m_TriggerVar;

        public string textLine => m_TextLine;
        public AudioClip audioClip => m_AudioClip;
        public LineTriggers trigger => m_Trigger;
        public int triggerVariable => m_TriggerVar;
        public int nextIndex => m_NextIndex;
        public UnityEvent runWhenTriggered => m_RunWhenTriggered;
    }

    [System.Serializable]
    public enum LineTriggers
    {
        None,
        OnTrigger,
        OnEnd,
        OnWait,
        OnEndWait
    }
}