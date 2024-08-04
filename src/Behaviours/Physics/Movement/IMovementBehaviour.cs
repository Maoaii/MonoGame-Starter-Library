using Microsoft.Xna.Framework;

namespace src.Behaviours.Physics.Movement {
    public interface IMovementBehaviour {
        void ReadInput();
        void Move();
    }
}