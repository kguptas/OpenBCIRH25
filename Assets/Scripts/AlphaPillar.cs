using UnityEngine;
using OpenBCI.Network.Streams; // make sure you import the right thing from the OpenBCI SDK package

public class AlphaPillar : MonoBehaviour
{
    public GameObject pillar;  // make sure you have a GameObject in the scene to represent the pillar
    [SerializeField] private AverageBandPowerStream AvBPStream; // attach the AverageBandPowerStream from the Unity prefab
    [SerializeField] private PPGMetricsStream PPGStream; // attach the PPGMetricsStream from the Unity prefab
    private float pillarHeight;

    // Start is called once before the first frame update
    void Start()
    {
        pillarHeight = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // log the alpha band power value to the unity console
        Debug.Log("Alpha: " + AvBPStream.AverageBandPower.Alpha);

        // scale the cylinder height based on the alpha band power
        pillarHeight = AvBPStream.AverageBandPower.Alpha;
        pillar.transform.localScale = new Vector3(1, pillarHeight, 1);
    }
}