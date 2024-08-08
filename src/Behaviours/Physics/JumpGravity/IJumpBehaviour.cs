

using MonoGameLibrary.Behaviours.DataSchemas;
using MonoGameLibrary.Entities;

namespace MonoGameLibrary.Behaviours.Physics.JumpGravity {
    public interface IJumpBehaviour {

        void Jump(Entity entity);
        void VariableJump(Entity entity);
        void ResetJump();
        float CalculateJumpForce(JumpAndGravitySchema jumpResource);
    }
}