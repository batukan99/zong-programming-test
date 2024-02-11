using UnityEngine;
using DG.Tweening;
using Zong.UI;

namespace Zong.Commands 
{
    public class BoxCommand : ICommand
    {
        private GrabbableObject stone;
        private Vector3 previousStonePosition;
        private Vector3 previousPlayerPosition;
        private Transform grabTransform;
        private CharacterController playerCharacterController;
        public BoxCommand (GrabbableObject stone, Transform grabTransform, CharacterController playerCharacterController)
        {
            this.stone = stone;
            this.grabTransform = grabTransform;
            this.playerCharacterController = playerCharacterController;
        }
        public void Execute()
        {
            previousStonePosition = stone.transform.position;
            previousPlayerPosition = playerCharacterController.transform.position;
        }

        public void Undo()
        {
            stone.Rigidbody.useGravity = false;
            stone.Rigidbody.MovePosition(previousStonePosition);
            stone.Grab(grabTransform, playerCharacterController);
            playerCharacterController.Move(previousPlayerPosition);
            Singleton<UIManager>.Instance.EnableMainPanel();
        }
    }

}
