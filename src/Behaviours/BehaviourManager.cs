using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
                if (behaviour is IPhysicalBehaviour) {
                    (behaviour as IPhysicalBehaviour).Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (var behaviour in behaviours.Values) {
                if (behaviour is IVisualBehaviour) {
                    (behaviour as IVisualBehaviour).Draw(spriteBatch);
                }
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