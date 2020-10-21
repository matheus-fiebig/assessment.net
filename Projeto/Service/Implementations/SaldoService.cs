using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Projeto.Model;
using Projeto.Repository;

namespace Projeto.Service
{
    public class SaldoService : ISaldoService
    {
        private readonly ISaldoRepository _repository;
        private readonly IMapper _mapper;

        public SaldoService(ISaldoRepository repository, IMapper mapper)
        {
            _repository = repository;     
            _mapper = mapper;
        }

        public int VerSaldo(string id){
            return Task.Run(()=>_repository.GetSaldo(id)).Result.SaldoAtual;
        }

        public SaldoModel MudarSaldo(SaldoModel model){

            if (model.SaldoAtual == 0){
                throw new System.Exception("Saldo a adicionar tem que ser diferente de 0.");
            }
            
            var novoSaldo = Task.Run(()=>_repository.EditSaldo(model.Id,model.SaldoAtual)).Result;

            return _mapper.Map<SaldoModel>(novoSaldo);
        }
        
        public List<int> SacarSaldo(SaldoModel model){

            if (model.SaldoAtual == 0){
                throw new System.Exception("Saldo a retirar tem que ser diferente de 0.");
            }

            var saldoAtual = Task.Run(()=>VerSaldo(model.Id)).Result;

            if(saldoAtual < model.SaldoAtual){
                throw new System.Exception("Saldo não pode ser negativo.");
            }

            var notas = CalcularNotas(model.SaldoAtual);
            
            model.SaldoAtual*=-1;
            MudarSaldo(model);


            return notas;
        }

        private List<int> CalcularNotas(int qntRetirar){
            var notas = new List<int>(){100,50,20,10};
            var qntNotas = new List<int>(){0,0,0,0};
            var i = 0;

            while(i<4){
                if (qntRetirar/notas[i]>=1){
                    qntRetirar -= notas[i];
                    qntNotas[i]++;
                }
                
                if(qntRetirar/notas[i]<1)
                    i++;
            }

            return qntNotas;
        }

    }
}