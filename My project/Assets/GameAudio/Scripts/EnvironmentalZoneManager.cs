using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.GameAudio.Scripts
{
    public class EnvironmentalZoneManager : MonoBehaviour
    {
        public AudioMixerSnapshot global;
        public AudioMixer master;
        public Transform player;
        public EnvironmentalZone[] zones;
        public List<InfluenceZone> influenceZones = new List<InfluenceZone>();

        private InfluenceZone globalInfluenceZone;

        private float range;
        void Start()
        {
            zones = GetComponentsInChildren<EnvironmentalZone>();
            globalInfluenceZone = new InfluenceZone
            {
                Snapshot = global,
                Weight = 1
            };
        }

        void Update()
        {
            influenceZones.Clear();
            influenceZones.Add(globalInfluenceZone);

            for (int i = 0; i < zones.Length; i++)
            {
                //zones only influence if they are within their influence
                var distance = Vector3.Distance(player.position, zones[i].transform.position);
                if (distance < zones[i].influence)
                {
                    influenceZones.Add(new InfluenceZone
                    {
                        Snapshot = zones[i].zone,
                        Weight = (1 - distance / zones[i].influence) * zones[i].weight
                    });
                }
            }
            //blend the zones together
            master.TransitionToSnapshots(GetSnapshots(), GetWeights(), 1);

        }

        private float[] GetWeights()
        {
            return influenceZones.Select(s => s.Weight).ToArray();
        }

        private AudioMixerSnapshot[] GetSnapshots()
        {
            return influenceZones.Select(s => s.Snapshot).ToArray();
        }
    }
}
public class InfluenceZone 
{
    public AudioMixerSnapshot Snapshot;
    public float Weight;

}
