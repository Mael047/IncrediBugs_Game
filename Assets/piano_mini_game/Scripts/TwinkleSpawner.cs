using UnityEngine;
using System.Collections.Generic;

public class TwinkleSpawner : MonoBehaviour {
    public GameObject notePrefab;
    public RectTransform spawnArea;

    public Sprite shortNoteSprite;
    public Sprite longNoteSprite;

    [System.Serializable]
    public class NoteData {
        public string note;
        public float time;
        public float duration;
    }

    public List<NoteData> songNotes = new List<NoteData>();

    private float songTime;

    void Start() {
        BuildSong();
    }

    void Update() {
        songTime += Time.deltaTime;

        foreach (var note in songNotes.ToArray())
        {
            if (note.time <= songTime)
            {
                SpawnNote(note);
                songNotes.Remove(note);
            }
        }
    }

    void SpawnNote(NoteData noteData) {
        GameObject go = Instantiate(notePrefab, spawnArea);
        var noteScript = go.GetComponent<FallingNote>();
        noteScript.note = noteData.note;
        noteScript.duration = noteData.duration;
        noteScript.shortNoteSprite = shortNoteSprite;
        noteScript.longNoteSprite = longNoteSprite;

        RectTransform rt = go.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(GetXPosition(noteData.note), 600f);
    }

    float GetXPosition(string note) {
        switch (note)
        {
            case "DO": return -522f;
            case "RE": return -348f;
            case "MI": return -174f;
            case "FA": return 2f;
            case "SOL": return 174f;
            case "LA": return 348f;
            case "SI": return 522f;
            default: return 0f;
        }
    }

    void BuildSong() {
        float t = 0f;
        float beat = 0.6f;

        songNotes.Add(new NoteData { note = "DO", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "DO", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "SOL", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "SOL", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "LA", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "LA", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "SOL", time = t, duration = beat * 2 }); t += beat * 2;
        songNotes.Add(new NoteData { note = "FA", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "FA", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "MI", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "MI", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "RE", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "RE", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "DO", time = t, duration = beat * 2 }); t += beat * 2;

        songNotes.Add(new NoteData { note = "SOL", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "SOL", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "FA", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "FA", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "MI", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "MI", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "RE", time = t, duration = beat * 2 }); t += beat * 2;
        songNotes.Add(new NoteData { note = "SOL", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "SOL", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "FA", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "FA", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "MI", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "MI", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "RE", time = t, duration = beat * 2 }); t += beat * 2;

        songNotes.Add(new NoteData { note = "DO", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "DO", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "SOL", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "SOL", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "LA", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "LA", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "SOL", time = t, duration = beat * 2 }); t += beat * 2;
        songNotes.Add(new NoteData { note = "FA", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "FA", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "MI", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "MI", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "RE", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "RE", time = t, duration = beat }); t += beat;
        songNotes.Add(new NoteData { note = "DO", time = t, duration = beat * 2 }); t += beat * 2;
    }
}
