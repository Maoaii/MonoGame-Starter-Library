using Microsoft.Xna.Framework;

namespace MonoGameLibrary.Behaviours.Physics.Colliders;
interface IColliderBehaviour {
    Rectangle Hitbox { get; }
    bool IsColliding(IColliderBehaviour other);
}