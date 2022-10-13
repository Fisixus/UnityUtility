using UnityEngine.EventSystems;

namespace UnityUtility.Input
{
	public static class InputUtility
	{
		public static bool GetMouseDown()
		{
			return UnityEngine.Input.GetMouseButtonDown(0) && EventSystem.current != null &&
#if UNITY_EDITOR
			       !EventSystem.current.IsPointerOverGameObject();
#elif UNITY_IOS || UNITY_ANDROID
			       !EventSystem.current.IsPointerOverGameObject(0);
#else
			       EventSystem.current.currentSelectedGameObject == null;
#endif
		}

		public static bool GetMouseHold()
		{
			return UnityEngine.Input.GetMouseButton(0) && EventSystem.current != null &&
#if UNITY_EDITOR
			       !EventSystem.current.IsPointerOverGameObject();
#elif UNITY_IOS || UNITY_ANDROID
			       !EventSystem.current.IsPointerOverGameObject(0);
#else
			       EventSystem.current.currentSelectedGameObject == null;
#endif
		}

		public static bool GetMouseUp()
		{
			return UnityEngine.Input.GetMouseButtonUp(0);
		}
	}
}
