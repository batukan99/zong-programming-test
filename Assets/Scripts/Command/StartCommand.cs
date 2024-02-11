using UnityEngine;
using DG.Tweening;

namespace Zong.Commands 
{
    public class StartCommand : ICommand
    {
        private GrabbableObject stone;
        private Vector3 previousStonePosition;
        public StartCommand (GrabbableObject stone)
        {
            this.stone = stone;
        }
        public void Execute()
        {
            previousStonePosition = stone.transform.position;
        }

        public void Undo()
        {
            stone.Rigidbody.MovePosition(previousStonePosition);
            stone.Rigidbody.useGravity = true;
        }
    }

}
