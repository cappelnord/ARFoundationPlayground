using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using Unity​Engine.XR.ARFoundation;
using UnityEngine.Video;



public class SpawnVideoPlayer : MonoBehaviour
{

    [SerializeField]
    private GameObject videoPlayerPrefab;

    [SerializeField]
    private GameObject videoPlayerButtonPrefab;

    private ARTrackedImage trackedImage;

    private GameObject videoPlayerObject;
    private GameObject videoPlayerButtonObject;

    public bool Loop = true;

    void Start()
    {
        trackedImage = GetComponent<ARTrackedImage>();
        XRReferenceImage referenceImage = trackedImage.referenceImage;

        videoPlayerObject = Instantiate(videoPlayerPrefab, transform);

        VideoPlayer videoPlayer = videoPlayerObject.GetComponent<VideoPlayer>();
        videoPlayer.clip = LinkReferenceToVideo.Get(referenceImage.name);
        videoPlayer.isLooping = Loop;
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        videoPlayerObject.transform.localScale = new Vector3(trackedImage.size.x * 0.1f, 1f, trackedImage.size.y * 0.1f);
    }
}
