using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InControl;


public class ControlBinding : PlayerActionSet
{
    public readonly PlayerAction Fire;
    public readonly PlayerAction Jump;
    public readonly PlayerAction Left;
    public readonly PlayerAction Right;
    public readonly PlayerAction Up;
    public readonly PlayerAction Down;
    public readonly PlayerTwoAxisAction Move;


    public ControlBinding()
    {
        Fire = CreatePlayerAction( "Fire" );
        Jump = CreatePlayerAction( "Jump" );
        Left = CreatePlayerAction( "Move Left" );
        Right = CreatePlayerAction( "Move Right" );
        Up = CreatePlayerAction( "Move Up" );
        Down = CreatePlayerAction( "Move Down" );
        Move = CreateTwoAxisPlayerAction( Left, Right, Down, Up );
    }


    public static ControlBinding CreateWithDefaultBindings()
    {
        var controlBinding = new ControlBinding();

        // How to set up mutually exclusive keyboard bindings with a modifier key.
        // playerActions.Back.AddDefaultBinding( Key.Shift, Key.Tab );
        // playerActions.Next.AddDefaultBinding( KeyCombo.With( Key.Tab ).AndNot( Key.Shift ) );

        // controlBinding.Fire.AddDefaultBinding( Key.A );
        // controlBinding.Fire.AddDefaultBinding( InputControlType.Action1 );
        // playerActions.Fire.AddDefaultBinding( Mouse.LeftButton );

        controlBinding.Jump.AddDefaultBinding( Key.Space );
        controlBinding.Jump.AddDefaultBinding( InputControlType.Action1);
        // controlBinding.Jump.AddDefaultBinding( InputControlType.Action3 );

        controlBinding.Up.AddDefaultBinding( Key.W );
        controlBinding.Down.AddDefaultBinding( Key.S );
        controlBinding.Left.AddDefaultBinding( Key.A );
        controlBinding.Right.AddDefaultBinding( Key.D );

        controlBinding.Left.AddDefaultBinding( InputControlType.LeftStickLeft );
        // controlBinding.Right.AddDefaultBinding( InputControlType.LeftStickRight );
        // controlBinding.Up.AddDefaultBinding( InputControlType.LeftStickUp );
        // controlBinding.Down.AddDefaultBinding( InputControlType.LeftStickDown );

        // controlBinding.Left.AddDefaultBinding( InputControlType.DPadLeft );
        // controlBinding.Right.AddDefaultBinding( InputControlType.DPadRight );
        // controlBinding.Up.AddDefaultBinding( InputControlType.DPadUp );
        // controlBinding.Down.AddDefaultBinding( InputControlType.DPadDown );

        // controlBinding.Up.AddDefaultBinding( Mouse.PositiveY );
        // controlBinding.Down.AddDefaultBinding( Mouse.NegativeY );
        // controlBinding.Left.AddDefaultBinding( Mouse.NegativeX );
        // controlBinding.Right.AddDefaultBinding( Mouse.PositiveX );

        controlBinding.ListenOptions.IncludeUnknownControllers = true;
        controlBinding.ListenOptions.MaxAllowedBindings = 4;
        // playerActions.ListenOptions.MaxAllowedBindingsPerType = 1;
        // playerActions.ListenOptions.AllowDuplicateBindingsPerSet = true;
        controlBinding.ListenOptions.UnsetDuplicateBindingsOnSet = true;
        // playerActions.ListenOptions.IncludeMouseButtons = true;
        // playerActions.ListenOptions.IncludeModifiersAsFirstClassKeys = true;
        // playerActions.ListenOptions.IncludeMouseScrollWheel = true;

        controlBinding.ListenOptions.OnBindingFound = ( action, binding ) =>
        {
            if (binding == new KeyBindingSource( Key.Escape ))
            {
                action.StopListeningForBinding();
                return false;
            }

            return true;
        };

        controlBinding.ListenOptions.OnBindingAdded += ( action, binding ) =>
        {
            Debug.Log( "Binding added... " + binding.DeviceName + ": " + binding.Name );

            // if (binding.BindingSourceType == BindingSourceType.DeviceBindingSource)
            // {
            // 	var control = ((DeviceBindingSource) binding).Control;
            // 	Debug.Log( control );
            // }
        };

        controlBinding.ListenOptions.OnBindingRejected += ( action, binding, reason ) => { Debug.Log( "Binding rejected... " + reason ); };

        return controlBinding;
    }
}
