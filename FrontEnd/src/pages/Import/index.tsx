import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';

import filesize from 'filesize';

import Header from '../../components/Header';
import FileList from '../../components/FileList';
import Upload from '../../components/Upload';

import { Container, Title, ImportFileContainer, Footer } from './styles';

import alert from '../../assets/alert.svg';
import api from '../../services/api';

interface FileProps {
  file: File;
  name: string;
  readableSize: string;
}

const Import: React.FC = () => {
  const [uploadedFiles, setUploadedFiles] = useState<FileProps[]>([]);
  const history = useHistory();

  async function handleUpload(): Promise<void> {
    try {
      uploadedFiles.forEach(async file => {
        const formData = new FormData();
        const imagefile = file.file;
        formData.append('file', imagefile);
        api.post('/Importacao', formData, {
          headers: {
            'Content-Type': 'multipart/form-data',
          },
        }).then(()=> {
          history.push('/');
        }).catch((erro)=>console.log(erro.response))
      });
    } catch (err) {
      console.log(err)
    }
  }

  function submitFile(files: File[]): void {
    const parsedFile: FileProps[] = files.map(file => ({
      file,
      name: file.name,
      readableSize: filesize(file.size),
    }));
    setUploadedFiles([...uploadedFiles, ...parsedFile]);
  }

  return (
    <>
      <Header size="small" />
      <Container>
        <Title>Importar uma planilha</Title>
        <ImportFileContainer>
          <Upload onUpload={submitFile} />
          {!!uploadedFiles.length && <FileList files={uploadedFiles} />}

          <Footer>
            <p>
              <img src={alert} alt="Alert" />
              Permitido apenas arquivos xlsx
            </p>
            <button onClick={handleUpload} type="button">
              Enviar
            </button>
          </Footer>
        </ImportFileContainer>
      </Container>
    </>
  );
};

export default Import;
