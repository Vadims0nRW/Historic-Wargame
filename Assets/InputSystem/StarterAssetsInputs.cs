using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool build;
        public bool pause;
        public bool menu;
        public bool enter;
        public bool fire;
        public bool turnr;
        public bool turnl;
        public bool interact;

        [Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnBuild(InputValue value)
		{
			BuildInput(value.isPressed);
		}

        public void OnPause(InputValue value)
        {
            PauseInput(value.isPressed);
        }

        public void OnMenu(InputValue value)
        {
            MenuInput(value.isPressed);
        }

        public void OnEnter(InputValue value)
        {
            EnterInput(value.isPressed);
        }

        public void OnFire(InputValue value)
        {
            FireInput(value.isPressed);
        }

        public void OnTurnR(InputValue value)
        {
            TurnRInput(value.isPressed);
        }

        public void OnTurnL(InputValue value)
        {
            TurnLInput(value.isPressed);
        }

        public void OnInteract(InputValue value)
        {
            InteractInput(value.isPressed);
        }

#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void BuildInput(bool newBuildState)
		{
			build = newBuildState;
		}

        public void PauseInput(bool newPauseState)
        {
            pause = newPauseState;
        }

        public void MenuInput(bool newMenuState)
        {
            menu = newMenuState;
        }

        public void EnterInput(bool newEnterState)
        {
            enter = newEnterState;
        }

        public void FireInput(bool newFireState)
        {
            fire = newFireState;
        }

        public void TurnRInput(bool newTurnRState)
        {
            turnr = newTurnRState;
        }

        public void TurnLInput(bool newTurnLState)
        {
            turnl = newTurnLState;
        }

        public void InteractInput(bool newInteractState)
        {
            interact = newInteractState;
        }

        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}