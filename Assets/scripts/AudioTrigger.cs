using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTrigger : MonoBehaviour
{
  public AudioMixerSnapshot snapshot;
  public float crossFade;

  void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("trigger detected");
    snapshot.TransitionTo(crossFade);
  }
}
