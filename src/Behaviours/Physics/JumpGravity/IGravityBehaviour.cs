using src.Behaviours.DataClasses;
using src.Entities;

namespace src.Behaviours.Physics.JumpGravity {
    public interface IGravityBehaviour {
        
        float CalculateGravity(JumpAndGravity gravityResource, Entity entity);
        void ApplyGravity(Entity entity);
    }
}