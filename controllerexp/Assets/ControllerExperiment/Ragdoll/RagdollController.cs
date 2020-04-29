﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControllerExperiment.SubComponents.Ragdoll;
using ControllerExperiment.States.Ragdoll;

namespace ControllerExperiment
{
    public enum SelectedRagdoll
    {
        COPY_DUMMY_ANIMATION,
        LIFELESS_RAGDOLL,
    }

    public class RagdollController : ControllerEntity
    {
        [Header("Attributes")]
        public SelectedRagdoll m_DesiredState;

        private void Start()
        {
            // init ragdoll state
            GetStateProcessor(STATE.RAGDOLL).TransitionTo(typeof(RagdollStart));

            subComponentProcessor.SetEntity(SetRagdoll.SET_RAGDOLL_DUMMY);
            subComponentProcessor.DelegateGetInt(RagdollInt.DESIRED_RAGDOLL_STATE, GetDesiredState);
        }

        private void Update()
        {
            UpdateStateProcessors();
        }

        private void FixedUpdate()
        {
            FixedUpdateStateProcessors();
            subComponentProcessor.FixedUpdateSubComponents();
        }

        int GetDesiredState()
        {
            return (int)m_DesiredState;
        }
    }
}