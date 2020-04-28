﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControllerExperiment.SubComponents;
using ControllerExperiment.PhysicsState;

namespace ControllerExperiment.Ragdoll
{
    public class RagdollController : ControllerEntity
    {
        private void Start()
        {
            stateProcessor.TransitionTo(typeof(RagdollStart));
            subComponentProcessor.ProcDic[RagdollProcess.SET_RAGDOLL_DUMMY]();
        }

        private void Update()
        {
            stateProcessor.UpdateState();
        }

        private void FixedUpdate()
        {
            stateProcessor.FixedUpdateState();
            subComponentProcessor.FixedUpdateSubComponents();
        }
    }
}