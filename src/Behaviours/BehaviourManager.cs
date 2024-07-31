using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;


namespace src.Behaviours {
    class BehaviourManager {
        Dictionary<string, EntityBehaviour> behaviours;

        public BehaviourManager() {
            behaviours = new Dictionary<string, EntityBehaviour>();
        }

        public void Update(GameTime gameTime) {
            foreach (var behaviour in behaviours.Values) {
                behaviour.Update(gameTime);
            }
        }

        public EntityBehaviour GetBehaviour(string name) {
            if (!behaviours.ContainsKey(name)) {
                return null;
            }

            return behaviours[name];
        }

        public void AddBehaviour(EntityBehaviour behaviour) {
            if (behaviours.ContainsKey(behaviour.GetType().Name)) {
                return;
            }

            behaviours.Add(behaviour.GetType().Name, behaviour);
        }

        public void RemoveBehaviour(EntityBehaviour behaviour) {
            behaviours.Remove(behaviour.GetType().Name);
        }
    }
}