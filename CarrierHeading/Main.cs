using Harmony;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


/*
Expectation:
Have the ATC voice read out his line of carrier landing procedures as well as the heading of the request carrier.

Reality:
ATC voice seemed impossible, I was hoping for a way to give it essentially text to speech but from my whole total of 1 hour looking at the ATCVoiveProfile.cs from the VTOL VR Assests
hat was determined to be, in fact, false. Using "inspiration" from the Subtitles mod (THE_GREAT_OVERLORD_OF_ALL_CHEESE) I used the Tutorial Message Display System instead. Using
Magic Carpet (Afroman) as a base as we would essentially be doing the exact same thing using Harmony to edit the already existing PlayerRequestLanding Method in the
AirportManager Class to also include a Tutorial Display for the heading of the requested carrier, the heading is gained from doing a transform on the carrier at that moment in time
the request was made to gain it's heading then display it.
*/
namespace CarrierHeading
{
    public class Main : VTOLMOD
    {
        // This method is run once, when the Mod Loader is done initialising this game object
        public override void ModLoaded()
        {
            //This is an event the VTOLAPI calls when the game is done loading a scene

            //Create and attempt Harmony Postfix edit.
            HarmonyInstance harmonyInstance = HarmonyInstance.Create("Carrier_Heading");
            try
            { 
                harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());            
            }
            catch
            {
                Debug.Log("Harmony was unable to Patch");
            }

            base.ModLoaded();
        }
    }
}