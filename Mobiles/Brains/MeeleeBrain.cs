﻿using UnityEngine;

namespace BeheaderTavern.Scripts.Mobiles.Brains
{
    public class MeeleeBrain : BaseBrain
    {
        private float Damage = 5f;
        private float attackCoolDown = 0;
        public override void Start()
        {
            base.Start();
        }
            

        public override void DoCombat()
        {
            base.DoCombat();
            m_creature.transform.LookAt(m_target.transform);
            if(attackCoolDown <= 0 && m_creature.InRange(m_target,targetDistance))
            {
                attackCoolDown = 2f;
                m_creature.animator.SetTrigger("MeeleeAttack");
                m_creature.agent.ResetPath();
                m_creature.agent.velocity = Vector3.zero;
            }
        }

        public void Update()
        {
            if (attackCoolDown > 0)
                attackCoolDown -= Time.deltaTime;
        }
    }
}

