using UnityEngine;
using System;

namespace NeutronCat.Classroom
{
    public class ClockAnim : MonoBehaviour
    {

        public Transform hours, minutes, seconds;
        public bool isWorking, isNow;
        public int initHours, initMinutes, initSeconds;

        private const float
            hoursToDegrees = 30f,
            minutesToDegrees = 6f,
            secondsToDegrees = 6f;
        private TimeSpan _timespan;
        private DateTime _dateTime;

        void Start()
        {
            if (!isNow)
            {
                _timespan = new TimeSpan(initHours, initMinutes, initSeconds);
            }
            else
            {
                _timespan = DateTime.Now.TimeOfDay;
                SetArms();
            }
        }

        void Update()
        {
            if (!isWorking) return;

            if (isNow)
            {
                _timespan = DateTime.Now.TimeOfDay;
            }
            else
            {
                _timespan = _timespan.Add(new TimeSpan(0, 0, 0, 0, (int)(Time.deltaTime * 1000f)));
            }

            SetArms();
        }

        void SetArms()
        {
            hours.localRotation = Quaternion.Euler(0f, 0f, (float)_timespan.TotalHours * hoursToDegrees);
            minutes.localRotation = Quaternion.Euler(0f, 0f, (float)_timespan.TotalMinutes * minutesToDegrees);
            seconds.localRotation = Quaternion.Euler(0f, 0f, (float)_timespan.TotalSeconds * secondsToDegrees);
        }
    }
}