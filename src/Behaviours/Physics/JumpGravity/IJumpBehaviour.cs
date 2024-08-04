

using src.Behaviours.DataClasses;
using src.Entities;

namespace src.Behaviours.Physics.JumpGravity {
    public interface IJumpBehaviour {

        void Jump(Entity entity);
        void VariableJump(Entity entity);
        void ResetJump();
        float CalculateJumpForce(JumpAndGravity jumpResource);
    }
}