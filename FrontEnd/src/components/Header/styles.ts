import styled from 'styled-components';

interface ContainerProps {
  size?: 'small' | 'large';
}

export const Container = styled.div<ContainerProps>`
  background: #03ECFF;
  padding: 30px 0;

  header {
    width: 1120px;
    margin: 0 auto;
    padding: 0 20px;
    display: flex;
    align-items: center;
    justify-content: space-between;

    nav {
      a {
        color: #C6098D;
        text-decoration: none;
        font-size: 16px;
        transition: opacity 0.2s;
        &:first-child {
          border-bottom: ${({ size }) =>
            size === 'large' ? '2px solid #ff872c' : ''};
        }
        & + a {
          margin-left: 32px;
          border-bottom: ${({ size }) =>
            size === 'small' ? '2px solid #ff872c' : ''};
        }

        &:hover {
          opacity: 0.6;
        }
      }
    }
  }
`;
