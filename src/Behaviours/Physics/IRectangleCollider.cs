using Microsoft.Xna.Framework;


interface IRectangleCollider {
    Rectangle Hitbox { get; }

    bool IsColliding(IRectangleCollider other);
}