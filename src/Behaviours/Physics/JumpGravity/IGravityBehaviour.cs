using MonoGameLibrary.Behaviours.DataSchemas;
using MonoGameLibrary.Entities;

namespace MonoGameLibrary.Behaviours.Physics.JumpGravity {
    public interface IGravityBehaviour {
        
        float CalculateGravity(JumpAndGravity gravityResource, Entity entity);
        void ApplyGravity(Entity entity);
    }
}