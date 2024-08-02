using Microsoft.Xna.Framework;


interface IColliderBehaviour {
    Rectangle Hitbox { get; }
    bool IsColliding(IColliderBehaviour other);
}