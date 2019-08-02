import React, {Fragment} from 'react';
import { Query } from 'react-apollo';
import { ESTUDIANTES_QUERY } from '../queries';


const Estudiantes = () => (
    
    <Query query={ESTUDIANTES_QUERY}>
    {
        ({ loading, error, data })=> {
            if(loading) return "Cargando..." ;
            if(error) return `Error: ${error.message}`;
            console.log(data.estudiantes);

            return (
                <Fragment>
                    <h2 className="text-center"> Listado de Estudiantes </h2>
                    <table>
                        <thead>
                            <tr>
                                <td>id</td>
                                <td>nombre</td>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                data.estudiantes.map(item =>  (
                                    <tr key={item.id}>
                                        <td>{item.id}</td>
                                        <td>{item.nombrePrimero}</td>
                                        <td>{item.nombreSegundo}</td>
                                        <td>{item.apellidoMaterno}</td>
                                        <td>{item.apellidoPaterno}</td>
                                    </tr>
                                 
                                ))
                            }
                        </tbody>
                    </table>
                </Fragment>
            )
        }
    }
    </Query>
)

export default Estudiantes