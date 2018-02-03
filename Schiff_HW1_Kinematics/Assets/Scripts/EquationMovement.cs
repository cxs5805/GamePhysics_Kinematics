using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationMovement : MonoBehaviour
{
    // Author: Chris Schiff
    // This script defines the behavior for the red cube,
    // which moves to precalculated exact values defined
    // by the kinematic equations. The blue cube, meanwhile,
    // uses Euler approximation to emulate said exact values.

    // NOTE: Both cubes have the same initial kinematic values.


    // an array to store the hard-coded values for x- and y- positions
    // for the first 120 frames
    private Vector3[] locations;
    private int numLocations;

    // frame counter to determine which location to move to
    public int counter;
    private int frameStarted;

	// Use this for initialization
	void Start ()
    {
        SetValues();
        Init();
	}

    // hard code all of the exact location values from the equations
    void SetValues()
    {
        locations = new Vector3[121];
        locations[0] = new Vector3(0.0f, 0.0f);

        locations[1] = new Vector3(0.0116669f, 0.165308834f);
        locations[2] = new Vector3(0.0233338f, 0.327895338f);
        locations[3] = new Vector3(0.0350007f, 0.48775951f);
        locations[4] = new Vector3(0.0466676f, 0.644901351f);
        locations[5] = new Vector3(0.0583345f, 0.799320861f);
        locations[6] = new Vector3(0.0700014f, 0.95101804f);
        locations[7] = new Vector3(0.0816683f, 1.099992888f);
        locations[8] = new Vector3(0.0933352f, 1.246245404f);
        locations[9] = new Vector3(0.1050021f, 1.38977559f);
        locations[10] = new Vector3(0.116669f, 1.530583444f);

        locations[11] = new Vector3(0.1283359f, 1.668668968f);
        locations[12] = new Vector3(0.1400028f, 1.80403216f);
        locations[13] = new Vector3(0.1516697f, 1.936673021f);
        locations[14] = new Vector3(0.1633366f, 2.066591551f);
        locations[15] = new Vector3(0.1750035f, 2.19378775f);
        locations[16] = new Vector3(0.1866704f, 2.318261618f);
        locations[17] = new Vector3(0.1983373f, 2.440013154f);
        locations[18] = new Vector3(0.2100042f, 2.55904236f);
        locations[19] = new Vector3(0.2216711f, 2.675349234f);
        locations[20] = new Vector3(0.233338f, 2.788933778f);

        locations[21] = new Vector3(0.2450049f, 2.89979599f);
        locations[22] = new Vector3(0.2566718f, 3.007935871f);
        locations[23] = new Vector3(0.2683387f, 3.113353421f);
        locations[24] = new Vector3(0.2800056f, 3.21604864f);
        locations[25] = new Vector3(0.2916725f, 3.316021527f);
        locations[26] = new Vector3(0.3033394f, 3.413272084f);
        locations[27] = new Vector3(0.3150063f, 3.50780031f);
        locations[28] = new Vector3(0.3266732f, 3.599606204f);
        locations[29] = new Vector3(0.3383401f, 3.688689767f);
        locations[30] = new Vector3(0.350007f, 3.775051f);

        locations[31] = new Vector3(0.3616739f, 3.858689901f);
        locations[32] = new Vector3(0.3733408f, 3.939606471f);
        locations[33] = new Vector3(0.3850077f, 4.017800709f);
        locations[34] = new Vector3(0.3966746f, 4.093272617f);
        locations[35] = new Vector3(0.4083415f, 4.166022194f);
        locations[36] = new Vector3(0.4200084f, 4.236049439f);
        locations[37] = new Vector3(0.4316753f, 4.303354354f);
        locations[38] = new Vector3(0.4433422f, 4.367936937f);
        locations[39] = new Vector3(0.4550091f, 4.429797189f);
        locations[40] = new Vector3(0.466676f, 4.48893511f);

        locations[41] = new Vector3(0.4783429f, 4.5453507f);
        locations[42] = new Vector3(0.4900098f, 4.599043959f);
        locations[43] = new Vector3(0.5016767f, 4.650014887f);
        locations[44] = new Vector3(0.5133436f, 4.698263483f);
        locations[45] = new Vector3(0.5250105f, 4.743789749f);
        locations[46] = new Vector3(0.5366774f, 4.786593683f);
        locations[47] = new Vector3(0.5483443f, 4.826675287f);
        locations[48] = new Vector3(0.5600112f, 4.864034559f);
        locations[49] = new Vector3(0.5716781f, 4.8986715f);
        locations[50] = new Vector3(0.583345f, 4.93058611f);

        locations[51] = new Vector3(0.5950119f, 4.959778389f);
        locations[52] = new Vector3(0.6066788f, 4.986248336f);
        locations[53] = new Vector3(0.6183457f, 5.009995953f);
        locations[54] = new Vector3(0.6300126f, 5.031021238f);
        locations[55] = new Vector3(0.6416795f, 5.049324193f);
        locations[56] = new Vector3(0.6533464f, 5.064904816f);
        locations[57] = new Vector3(0.6650133f, 5.077763108f);
        locations[58] = new Vector3(0.6766802f, 5.087899069f);
        locations[59] = new Vector3(0.6883471f, 5.095312699f);
        locations[60] = new Vector3(0.700014f, 5.100003998f);

        locations[61] = new Vector3(0.7116809f, 5.101972966f);
        locations[62] = new Vector3(0.7233478f, 5.101219602f);
        locations[63] = new Vector3(0.7350147f, 5.097743908f);
        locations[64] = new Vector3(0.7466816f, 5.091545882f);
        locations[65] = new Vector3(0.7583485f, 5.082625525f);
        locations[66] = new Vector3(0.7700154f, 5.070982838f);
        locations[67] = new Vector3(0.7816823f, 5.056617819f);
        locations[68] = new Vector3(0.7933492f, 5.039530469f);
        locations[69] = new Vector3(0.8050161f, 5.019720787f);
        locations[70] = new Vector3(0.816683f, 4.997188775f);

        locations[71] = new Vector3(0.8283499f, 4.971934432f);
        locations[72] = new Vector3(0.8400168f, 4.943957757f);
        locations[73] = new Vector3(0.8516837f, 4.913258752f);
        locations[74] = new Vector3(0.8633506f, 4.879837415f);
        locations[75] = new Vector3(0.8750175f, 4.843693747f);
        locations[76] = new Vector3(0.8866844f, 4.804827748f);
        locations[77] = new Vector3(0.8983513f, 4.763239418f);
        locations[78] = new Vector3(0.9100182f, 4.718928757f);
        locations[79] = new Vector3(0.9216851f, 4.671895764f);
        locations[80] = new Vector3(0.933352f, 4.622140441f);

        locations[81] = new Vector3(0.9450189f, 4.569662786f);
        locations[82] = new Vector3(0.9566858f, 4.514462801f);
        locations[83] = new Vector3(0.9683527f, 4.456540484f);
        locations[84] = new Vector3(0.9800196f, 4.395895836f);
        locations[85] = new Vector3(0.9916865f, 4.332528857f);
        locations[86] = new Vector3(1.0033534f, 4.266439547f);
        locations[87] = new Vector3(1.0150203f, 4.197627906f);
        locations[88] = new Vector3(1.0266872f, 4.126093934f);
        locations[89] = new Vector3(1.0383541f, 4.05183763f);
        locations[90] = new Vector3(1.050021f, 3.974858996f);

        locations[91] = new Vector3(1.0616879f, 3.89515803f);
        locations[92] = new Vector3(1.0733548f, 3.812734733f);
        locations[93] = new Vector3(1.0850217f, 3.727589105f);
        locations[94] = new Vector3(1.0966886f, 3.639721146f);
        locations[95] = new Vector3(1.1083555f, 3.549130856f);
        locations[96] = new Vector3(1.1200224f, 3.455818235f);
        locations[97] = new Vector3(1.1316893f, 3.359783283f);
        locations[98] = new Vector3(1.1433562f, 3.261025999f);
        locations[99] = new Vector3(1.1550231f, 3.159546385f);
        locations[100] = new Vector3(1.16669f, 3.055344439f);

        locations[101] = new Vector3(1.1783569f, 2.948420162f);
        locations[102] = new Vector3(1.1900238f, 2.838773554f);
        locations[103] = new Vector3(1.2016907f, 2.726404615f);
        locations[104] = new Vector3(1.2133576f, 2.611313345f);
        locations[105] = new Vector3(1.2250245f, 2.493499744f);
        locations[106] = new Vector3(1.2366914f, 2.372963812f);
        locations[107] = new Vector3(1.2483583f, 2.249705548f);
        locations[108] = new Vector3(1.2600252f, 2.123724954f);
        locations[109] = new Vector3(1.2716921f, 1.995022028f);
        locations[110] = new Vector3(1.283359f, 1.863596771f);

        locations[111] = new Vector3(1.2950259f, 1.729449183f);
        locations[112] = new Vector3(1.3066928f, 1.592579264f);
        locations[113] = new Vector3(1.3183597f, 1.452987014f);
        locations[114] = new Vector3(1.3300266f, 1.310672433f);
        locations[115] = new Vector3(1.3416935f, 1.165635521f);
        locations[116] = new Vector3(1.3533604f, 1.017876277f);
        locations[117] = new Vector3(1.3650273f, 0.867394703f);
        locations[118] = new Vector3(1.3766942f, 0.714190797f);
        locations[119] = new Vector3(1.3883611f, 0.55826456f);
        locations[120] = new Vector3(1.400028f, 0.399615992f);
    }

    public void Init()
    {
        // start the counter and set the frame
        counter = 0;
        frameStarted = Time.frameCount;
    }

    // Update is called once per frame
    void Update ()
    {
        // stop updating position after 2 seconds
        if (counter <= 120)
            transform.position = locations[counter];

        // increment counter
        //counter++;
        counter = Time.frameCount - frameStarted;
	}
}
