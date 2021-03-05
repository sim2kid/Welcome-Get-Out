using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 0, fileName = "Narration", menuName = "Narration")]
public class Narration : ScriptableObject
{
    public List<VoiceLine> voiceLines;

    [System.Serializable]
    public class VoiceLine 
    {
        [SerializeField]
        private int m_NextIndex;

        [SerializeField]
        private LineContent m_Content;

        [SerializeField]
        private LineTriggers m_Trigger;
        [SerializeField]
        private string m_TriggerVar;

        public LineContent content => m_Content;
        public LineTriggers trigger => m_Trigger;
        public string triggerVariable => m_TriggerVar;
        public int nextIndex => m_NextIndex;
    }

    [System.Serializable]
    public struct LineContent 
    {
        [SerializeField]
        private string m_TextLine;
        [SerializeField]
        private AudioClip m_AudioClip;

        public LineContent(string textLine, AudioClip audioClip) : this() 
        {
            this.m_TextLine = textLine;
            this.m_AudioClip = audioClip;
        }

        public string textLine => m_TextLine;
        public AudioClip audioClip => m_AudioClip;

        public static LineContent none => new LineContent();
    }

    [System.Serializable]
    public enum LineTriggers
    {
        None,
        OnTrigger,
        OnWait
    }
}