﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Entity : MonoBehaviour
    {
        protected Rigidbody2D rb;
        public virtual void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
}
