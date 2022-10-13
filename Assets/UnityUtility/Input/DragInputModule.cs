using System.Runtime.CompilerServices;
using UnityEngine;
using UnityUtility.Singleton;

namespace UnityUtility.Input
{
	[DefaultExecutionOrder(-100)]
	public class DragInputModule:SingletonModule<DragInputModule>
	{

		public static Vector3 mousePosition;
		public static Vector3 MouseDownPosition     { get; internal set; }
		public static Vector3 MousePreviousPosition { get; internal set; }
		
		public static bool MouseDown { get; internal set; }
		public static bool MouseUp   { get; internal set; }
		public static bool MouseHold { get; internal set; }
		internal static bool CanSwipe { get; set; }
		
		private void Awake()
		{
			if(IsInstanceSetupBefore())
				return;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetDrag(Vector3 axis, float sensitivity = 12f) =>
			GetDrag(MousePreviousPosition, axis, sensitivity);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float GetDrag(Vector3 mouseAnchorPosition, Vector3 axis, float sensitivity = 12f)
		{
			return MouseHold ? Vector3.Dot(axis, mousePosition - mouseAnchorPosition) * sensitivity / Screen.width : 0f;
		}

		public void Update()
		{
			MouseDown = UnityEngine.Input.GetMouseButtonDown(0);
			//MouseUp = UnityEngine.Input.GetMouseButtonUp(0);
			MouseHold = UnityEngine.Input.GetMouseButton(0);

			if (MouseDown)
			{
				mousePosition = UnityEngine.Input.mousePosition;
				MousePreviousPosition = mousePosition;
				MouseDownPosition = mousePosition;
				CanSwipe = true;
				return;
			}

			MousePreviousPosition = mousePosition;
			mousePosition = UnityEngine.Input.mousePosition;
		}

	}
}
