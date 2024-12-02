using GamePrototype.Combat;
using GamePrototype.Dungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items
{
    internal class TranslationItems
    {
    }

    struct RockPaperScissorsName
    {
        public string Name(RockPaperScissors rockPaperScissors)
        {
            switch (rockPaperScissors)
            {
                case RockPaperScissors.Rock:
                    return "Камень";
                    break;
                case RockPaperScissors.Paper:
                    return "Бумага";
                    break;
                case RockPaperScissors.Scissors:
                    return "Ножницы";
                    break;
                default:
                    return "Ошибка перевода";
                    break;
            }

        }
    }

    struct DirectionName
    {
        public string Name(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return "Налево";
                    break;
                case Direction.Forward:
                    return "Прямо";
                    break;
                case Direction.Right:
                    return "Направо";
                    break;
                default:
                    return "Ошибка перевода";
                    break;
            }
        }
    }
}
