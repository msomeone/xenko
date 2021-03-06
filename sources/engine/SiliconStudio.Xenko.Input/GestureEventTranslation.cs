﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;

using SiliconStudio.Core.Mathematics;

namespace SiliconStudio.Xenko.Input
{
    /// <summary>
    /// Event class for the Drag gesture.
    /// </summary>
    public class GestureEventTranslation : GestureEvent
    {
        /// <summary>
        /// The Shape of the drag.
        /// </summary>
        public GestureShape Shape { get; internal set; }

        /// <summary>
        /// The position (in pixels) where the drag event started.
        /// </summary>
        public Vector2 StartPosition { get; internal set; }

        /// <summary>
        /// The current position (in pixels) of the drag event.
        /// </summary>
        public Vector2 CurrentPosition { get; internal set; }

        /// <summary>
        /// The translation (in pixels) performed since the last event of the gesture.
        /// </summary>
        public Vector2 DeltaTranslation { get; internal set; }

        /// <summary>
        /// The translation (in pixels) performed since the beginning of the gesture.
        /// </summary>
        public Vector2 TotalTranslation { get; internal set; }

        /// <summary>
        /// The average translation speed (in pixels per seconds) of the drag event.
        /// </summary>
        public Vector2 AverageSpeed { get; internal set; }

        internal GestureEventTranslation(GestureType type, GestureState state, int numberOfFingers, TimeSpan deltaTime, TimeSpan totalTime, 
                                          GestureShape shape, Vector2 startPos, Vector2 currPos, Vector2 deltaTrans)
        {
            Type = type;
            State = state;
            NumberOfFinger = numberOfFingers;
            DeltaTime = deltaTime;
            TotalTime = totalTime;
            Shape = shape;
            StartPosition = startPos;
            CurrentPosition = currPos;
            DeltaTranslation = deltaTrans;
            TotalTranslation = currPos - startPos;
            AverageSpeed = TotalTranslation / (float)(TotalTime.TotalSeconds + 0.0001f); // avoid division by zero
        }
    }
}