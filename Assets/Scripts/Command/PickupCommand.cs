using UnityEngine;
using DG.Tweening;
using Zong.UI;

namespace Zong.Commands 
{
    public class PickupCommand : ICommand
    {
        private GrabbableObject stone;
        private Vector3 previousStonePosition;
        private Vector3 previousPlayerPosition;
        private Transform grabTransform;
        private CharacterController playerCharacterController;
        public PickupCommand (GrabbableObject stone, Transform grabTransform, CharacterController playerCharacterController, Vector3 startPosition)
        {
            this.stone = stone;
            this.grabTransform = grabTransform;
            this.playerCharacterController = playerCharacterController;
            this.previousPlayerPosition = startPosition;
        }
        public void Execute()
        {
            previousStonePosition = stone.transform.position;
        }

        public void Undo()
        {
            stone.Rigidbody.useGravity = false;
            stone.Rigidbody.MovePosition(previousStonePosition);
            stone.Grab(grabTransform, playerCharacterController);
            playerCharacterController.enabled = false;
            playerCharacterController.transform.position = previousPlayerPosition;
            playerCharacterController.enabled = true;
            Cursor.visible = true;
        }
    }

}
