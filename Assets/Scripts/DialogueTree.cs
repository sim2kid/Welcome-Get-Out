using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        private LineTriggers m_Trigger;
        [SerializeField]
        private string m_TriggerVar;

        public string textLine => m_TextLine;
        public AudioClip audioClip => m_AudioClip;
        public LineTriggers trigger => m_Trigger;
        public string triggerVariable => m_TriggerVar;
        public int nextIndex => m_NextIndex;
    }

    [System.Serializable]
    public enum LineTriggers
    {
        None,
        OnTrigger,
        OnWait
    }
}