import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import api from '../../services/api';

import Header from '../../components/Header';

import { Container, TableContainer } from './styles';


interface Produto {
    id: string
    dtEntrega: Date;
    nmProduto: string;
    quantidade: Number;
    vlUnitario: Number;
  }
  

const Detail: React.FC = () => {
    const {id} = useParams();
    const [produtos, setProdutos] = useState<Produto[]>([])
    useEffect(()=>{
        async function carregarImportacoes(): Promise<void> {
            const response = await api.get(`/importacao/${id}`);
            setProdutos(response.data.produtos)
          }
          carregarImportacoes();
    }, [id])
    return (
        <>
        <Header />
            <Container>
        <TableContainer>
          <table>
            <thead>
              <tr>
                <th>Id</th>
                <th>Nome</th>
                <th>Quantidade</th>
                <th>Valor unitário</th>
                <th>Data entrega</th>
              </tr>
            </thead>

            <tbody>
              {produtos.map(produto => {
                return (
                <tr key={produto.id}>
                <td className="title">{produto.id}</td>
                <td>{produto.nmProduto}</td>
                <td>{produto.quantidade}</td>
                <td>{produto.vlUnitario}</td>
                <td>{new Date(produto.dtEntrega).toLocaleDateString('pt-BR')}</td>
              </tr>)
              })}
            </tbody>
          </table>
        </TableContainer>
      </Container>
        </>
    )
}


export default Detail;
