using Asteroids2D_GameLogic.Architecture.Objects;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GameLogicUnitTests")]
namespace Asteroids2D_GameLogic.Architecture.Components
{
    internal class Collider2D : Component
    {
        public readonly float Size;
        public Collider2D(float size, BaseObject parent) : base(parent)
        {
            Size = size;
        }

        public List<Collider2D> GetContacts(List<Collider2D> coliders)
        {
            List<Collider2D> contactColliders = new List<Collider2D>();
            foreach (var item in coliders)
            {
                if (item.baseObject != baseObject)
                {
                    var distanceVector = item.baseObject.transform.position - baseObject.transform.position;
                    float distance = (float)Math.Sqrt(distanceVector.x * distanceVector.x +
                        distanceVector.y * distanceVector.y) - item.baseObject.Size - baseObject.Size;

                    if (distance <= 0)
                    {
                        contactColliders.Add(item);
                    }
                }

            }
            return contactColliders;
        }
    }
}
