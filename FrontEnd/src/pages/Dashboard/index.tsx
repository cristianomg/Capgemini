import React, { useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom';

import api from '../../services/api';

import Header from '../../components/Header';


import { Container, TableContainer } from './styles';

interface Importacao {
  id: string;
  dtImportacao: Date;
  produtos: Produto[];
}

interface Produto {
  dtEntrega: Date;
  nmProduto: string;
  quantidade: Number;
  vlUnitario: Number;
}

const Dashboard: React.FC = () => {
  const [importacoes, setImportacoes] = useState<Importacao[]>([]);
  const history = useHistory();
  const handleClickImportacao = async(id: string) =>{
    console.log(id)
    history.push(`/detail/${id}`)
  }

  useEffect(() => {
    async function carregarImportacoes(): Promise<void> {
      const response = await api.get('/Importacao');
      setImportacoes(response.data)
      console.log(response)
    }

    carregarImportacoes();
  }, []);

  return (
    <>
      <Header />
      <Container>
        <TableContainer>
          <table>
            <thead>
              <tr>
                <th>Id</th>
                <th>Data de Importação</th>
                <th>Quantidade de Produtos</th>
              </tr>
            </thead>

            <tbody>
              {importacoes.map(importacao => {
                return (
                <tr key={importacao.id} onClick={()=>handleClickImportacao(importacao.id)}>
                <td className="title">{importacao.id}</td>
                <td>{new Date(importacao.dtImportacao).toLocaleDateString('pt-BR')}</td>
                <td>{importacao.produtos.length}</td>
              </tr>)
              })}
            </tbody>
          </table>
        </TableContainer>
      </Container>
    </>
  );
};

export default Dashboard;
