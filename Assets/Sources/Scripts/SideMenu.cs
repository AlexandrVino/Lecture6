using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenu : MonoBehaviour
{
    // Enum class with animation consts
    public static class Animations
    {
        public static readonly string Default = "Default";
        public static readonly string MenuOpenAnim = "MenuOpenAnim";
        public static readonly string MenuCloseAnim = "MenuCloseAnim";
    }

    // significant types
    private string _currAnimation = Animations.Default;
    private bool _isActive = true;

    // The other components of character
    [SerializeField] private Animator _animator;

    private void ChangeAnimation(string animation)
    {
        /*
         Mwthod for changing current animation
        */

        if (animation == _currAnimation) return;
        _animator.Play(animation);
        _currAnimation = animation;
    }

    public void Switch() {
        _isActive = !_isActive;
        ChangeAnimation(_isActive ? Animations.MenuOpenAnim : Animations.MenuCloseAnim);
    }

}
