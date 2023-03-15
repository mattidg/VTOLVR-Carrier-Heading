using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace CarrierHeading
{
    [HarmonyPatch(typeof(AirportManager), "PlayerRequestLanding")]

    class RequestLandingPatch
    {
        public static void Postfix(AirportManager __instance)
        {
            bool isCarrier = false;

            //Checks to make sure the ATC is in fact, a carrier.
            if (__instance.isCarrier)
            {
                bool noRunway = __instance.runways.Length == 0;

                if (!noRunway)
                {
                    if (__instance.team != Teams.Enemy)
                    {
                        bool hasArrestor = __instance.hasArrestor;

                        if (hasArrestor)
                        {
                            isCarrier = true;
                        }
                    }
                }
            }

            if (isCarrier)
            {
                //Create and read out the variable for the requested carriers heading. This will also round to the nearest whole number as it's impossible to see if you are heading 69.333, repeating of course.
                float carrierBearing = VectorUtils.Bearing(__instance.transform.position, __instance.transform.position + __instance.transform.forward);
                TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + " Carrier Heading: " + Math.Round(carrierBearing), null, 7);
            }
        }
    }
}