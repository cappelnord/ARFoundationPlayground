using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LinkReferenceToVideo : MonoBehaviour
{
    private static Dictionary<string, VideoClip> dict = new Dictionary<string, VideoClip>();

    public static void Add(string key, VideoClip video) => dict.Add(key, video);

    public static VideoClip Get(string key) => dict[key];


    [SerializeField]
    private string referenceImageName;

    [SerializeField]
    private VideoClip video;

    void Awake() {
        Add(referenceImageName, video);
        Destroy(gameObject);
    }

}
