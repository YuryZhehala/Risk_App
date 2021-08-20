using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data.Entities;

namespace Data.EFContext
{
    class SourceRiskInitializer : CreateDatabaseIfNotExists<SourceRiskContext>
    {
        protected override void Seed(SourceRiskContext context)
        {
            context.RiskSources.AddRange(new RiskSource[] {
                new RiskSource { RiskSourceName = "Риск персонала" },
                new RiskSource { RiskSourceName = "Риск ИТ" },
                new RiskSource { RiskSourceName = "Методологический риск" },
                new RiskSource { RiskSourceName = "Внешний риск" },


            });
            context.Incidents.AddRange(new Incident[]
            {
                
                        new Incident { 
                            DateOfIncident=new DateTime (2021, 2,6),
                            Description="Неверно составлен договор кредитования, указана утратившая силу процентная ставка",
                            DirectLossType=700,
                            PotentialLossType=700, 
                            Assessment=3, 
                            Measures="Обновить информацию о тарифая на корпоративном сайте, провести инструктаж с работниками",
                            RiskObjectId=1,
                            RiskSourceId=1,
                            Status = "Урегулирован",
                            LossTypeId=3,
                            UnitId=1},

                        new Incident { 
                            DateOfIncident=new DateTime (2021, 2,8),
                            Description="Начислена премия выше допустимой Сидорову И.А. за март 2021 г.",
                            DirectLossType=0,
                            PotentialLossType=600,
                            Assessment=2,
                            Measures="Произведен перерасчет, Сидоров И.А. уведомлен",
                            Status = "Урегулирован",
                            RiskObjectId=6,
                            RiskSourceId=1,
                            LossTypeId=5,
                            UnitId=6},

                        new Incident {
                            DateOfIncident=new DateTime (2021, 2,17),
                            Description="В договоре кредитования организации указан неверный процент по выплатам",
                            DirectLossType=0,
                            PotentialLossType=9500,
                            Assessment=3,
                            Measures="Внесены изменения в договор, провести инструктаж по составлению договоров",
                            Status = "Урегулирован",
                            RiskObjectId=2,
                            RiskSourceId=1,
                            LossTypeId=3,
                            UnitId=2},

                        new Incident {
                            DateOfIncident=new DateTime (2021, 3,17),
                            Description="Допущена ощибка в фамилии при выпуске банковской карты",
                            DirectLossType=0,
                            PotentialLossType=100,
                            Assessment=1,
                            Measures="Карта перевыпущена, с работником проведен инструктаж",
                            Status = "Урегулирован",
                            RiskObjectId=7,
                            RiskSourceId=1,
                            LossTypeId=4,
                            UnitId=1},
               
                
                        new Incident { 
                            DateOfIncident=new DateTime (2021, 2,25),
                            Description="Вышел из строя ПК в Бухгалтерия",
                            DirectLossType=1500,
                            PotentialLossType=1500,
                            Assessment=3,
                            Measures="ПК восстановлению не подлежит, причина поломки не выявлена",
                            Status = "Урегулирован",
                            RiskObjectId=4,
                            RiskSourceId=2,
                            LossTypeId=2,
                            UnitId=6},

                        new Incident { 
                            DateOfIncident=new DateTime (2021, 3,24),
                            Description="Упал сервер, была парализована работа 6 подразделений в течение 5 часов",
                            DirectLossType=500,
                            PotentialLossType=5100,
                            Assessment=4,
                            Measures="Исправлен баг, сервер перезапущен.",
                            Status = "Урегулирован",
                            RiskObjectId=4,
                            RiskSourceId=2,
                            LossTypeId=4,
                            UnitId=4},

                        new Incident {
                            DateOfIncident=new DateTime (2021, 2,26),
                            Description="Вышла из строя 1С",
                            DirectLossType=300,
                            PotentialLossType=1500,
                            Assessment=3,
                            Measures="Осуществлена доработка программного модуля",
                            Status = "Урегулирован",
                            RiskObjectId=4,
                            RiskSourceId=2,
                            LossTypeId=4,
                            UnitId=6},

                        new Incident {
                            DateOfIncident=new DateTime (2021, 4,6),
                            Description="Вышел из строя ноутбук в Управлении розничного бизнеса",
                            DirectLossType=0,
                            PotentialLossType=400,
                            Assessment=1,
                            Measures="Осуществлен осмотр и ремонт на месте",
                            Status = "Урегулирован",
                            RiskObjectId=4,
                            RiskSourceId=2,
                            LossTypeId=4,
                            UnitId=8},
                    
                        new Incident {
                            DateOfIncident=new DateTime (2021, 5,9),
                            Description="При разработке кредита 'На потребительские нужды' не учтены повышенные кредитные риски",
                            DirectLossType=0,
                            PotentialLossType=3000,
                            Assessment=4,
                            Measures="Проведено совещание, условия кредита подверглись пересмотру",
                            Status = "Урегулирован",
                            RiskObjectId=1,
                            RiskSourceId=3,
                            LossTypeId=3,
                            UnitId=1},                        
                 

                
                        new Incident {
                            DateOfIncident=new DateTime (2021, 6,9),
                            Description="Договор кредитования заключен по поддельным документам. Кредитополучатель не найден",
                            DirectLossType=4500,
                            PotentialLossType=4500,
                            Assessment=5,
                            Measures="Кредитополучатель в поиске. Начальнику Обеспечение безопасности объявлен выговор",
                            Status = "Не урегулирован",
                            RiskObjectId=5,
                            RiskSourceId=4,
                            LossTypeId=5,
                            UnitId=5},
                   
            });
            context.RiskObjects.AddRange(new RiskObject[] 
            { 
                new RiskObject { RiskObjectName = "Кредитование частных лиц" },
                new RiskObject { RiskObjectName = "Кредитование организаций" },
                new RiskObject { RiskObjectName = "Хозяйственное обеспечение" },
                new RiskObject { RiskObjectName = "Информационное обеспечение" },
                new RiskObject { RiskObjectName = "Обеспечение безопасности"},
                new RiskObject { RiskObjectName = "Бухгалтерский учет"},
                new RiskObject { RiskObjectName = "Операции с банковскими картами"},
                new RiskObject { RiskObjectName = "Риск-менеджмент"},
                new RiskObject { RiskObjectName = "Возврат имущества"},
                new RiskObject { RiskObjectName = "Юридическое сопровождение"},
                new RiskObject { RiskObjectName = "Работа с персоналом"},});

            context.LossTypes.AddRange(new LossType[] { 
                new LossType { LossTypeName = "Штрафы и взыскания" }, 
                new LossType { LossTypeName = "Порча имущества" }, 
                new LossType { LossTypeName = "Недополученная прибыль" },
                new LossType { LossTypeName = "Сбои ПО и оборудования" },
                new LossType { LossTypeName = "Излишние выплаты" },
            });

            context.Units.AddRange(new Unit[] 
            { 
                new Unit { UnitName = "Управление розничного бизнеса" },
                new Unit { UnitName = "Управление корпоративного бизнеса" },
                new Unit { UnitName = "Управление хозяйством" },
                new Unit { UnitName = "Управление информационных технологий." },
                new Unit { UnitName = "Управление безопасности и контроля" },
                new Unit { UnitName = "Бухгалтерия"},
                new Unit { UnitName = "Управление операций на фондовом рынке"},
                new Unit { UnitName = "Управление рисков"},
                new Unit { UnitName = "Управление возврата имущества"},
                new Unit { UnitName = "Юридическое управление"},
                new Unit { UnitName = "Управление персонала"} });

            context.FrequencyAssessment.AddRange(new FrequencyAssessment[] 
            { 
                new FrequencyAssessment { FrequencyAssessmentName = "Инцидент произошел впервые", FrequencyAssessmentRange="0 - 1.0", FrequencyAssessmentValue=1},
                new FrequencyAssessment { FrequencyAssessmentName = "Инцидент происходил в течение года", FrequencyAssessmentRange = "1.0 - 2.0", FrequencyAssessmentValue=2 },
                new FrequencyAssessment { FrequencyAssessmentName = "Инцидент происходил в течение года от 2 до 4 раз", FrequencyAssessmentRange = "2.0 - 3.0", FrequencyAssessmentValue=3 },
                new FrequencyAssessment { FrequencyAssessmentName = "Инцидент происходил в течение года от 5 до 7 раз", FrequencyAssessmentRange = "3.0 - 4.0", FrequencyAssessmentValue=4 },
                new FrequencyAssessment { FrequencyAssessmentName = "Инцидент происходил в течение года от 8 раз и чаще", FrequencyAssessmentRange = "4.0 - 5.0", FrequencyAssessmentValue=5 } });

            context.LossAssessments.AddRange(new LossAssessment[] { 
                new LossAssessment { LossAssessmentName = "Прямые потери не зафиксированы", LossAssessmentRange = "0 - 1.0", LossAssessmentValue=1 }, 
                new LossAssessment { LossAssessmentName = "Потери зафиксированы от 1 до 1 000 руб.", LossAssessmentRange= "1.0 - 2.0", LossAssessmentValue=2 }, 
                new LossAssessment { LossAssessmentName = "Потери зафиксированы от 1 000 до 20 000 руб.", LossAssessmentRange = "2.0 - 3.0", LossAssessmentValue=3 }, 
                new LossAssessment { LossAssessmentName = "Потери зафиксированы от 20 000 руб. до 30 000 руб.", LossAssessmentRange = "3.0 - 4.0", LossAssessmentValue=4 }, 
                new LossAssessment { LossAssessmentName = "Потери зафиксированы от 30 000 руб.", LossAssessmentRange = "4.0 - 5.0", LossAssessmentValue=5 } });

            context.QuantityAssessments.AddRange(new QuantityAssessment[] { 
                new QuantityAssessment { QuantityAssessmentName = "Инцидент затронул 1 подразделение", QuantityAssessmentRange= "0 - 1.0", QuantityAssessmentValue=1 }, 
                new QuantityAssessment { QuantityAssessmentName = "Инцидент затронул 2 подразделения", QuantityAssessmentRange= "1.0 - 2.0", QuantityAssessmentValue=2 },
                new QuantityAssessment { QuantityAssessmentName = "Инцидент затронул от 3 до 4 подразделений", QuantityAssessmentRange= "2.0 - 3.0", QuantityAssessmentValue=3 }, 
                new QuantityAssessment { QuantityAssessmentName = "Инцидент затронул от 5 до 6 подразделений", QuantityAssessmentRange= "3.0 - 4.0", QuantityAssessmentValue=4 },
                new QuantityAssessment { QuantityAssessmentName = "Инцидент затронул более 6 подразделений", QuantityAssessmentRange= "4.0 - 5.0", QuantityAssessmentValue=5 } });

            context.DurationAssessments.AddRange(new DurationAssessment[] { 
                new DurationAssessment { DurationAssessmentName = "Инцидент длился до 5 минут", DurationAssessmentRange= "0 - 1.0", DurationAssessmentValue=1 }, 
                new DurationAssessment { DurationAssessmentName = "Инцидент длился от 5 до 30 минут", DurationAssessmentRange = "1.0 - 2.0", DurationAssessmentValue=2 }, 
                new DurationAssessment { DurationAssessmentName = "Инцидент длился от 30 минут до 1 часа", DurationAssessmentRange = "2.0 - 3.0", DurationAssessmentValue=3 },
                new DurationAssessment { DurationAssessmentName = "Инцидент длился от 1 часа до 2 часов", DurationAssessmentRange = "3.0 - 4.0", DurationAssessmentValue=4 }, 
                new DurationAssessment { DurationAssessmentName = "Инцидент длился свыше 2 часов", DurationAssessmentRange = "4.0 - 5.0", DurationAssessmentValue=5 } });

            context.SaveChanges();
        }
    }
}