import React, { Component} from 'react';
import { ApolloProvider } from 'react-apollo';
import ApolloClient from 'apollo-boost';
import 'cross-fetch/polyfill';

import Estudiantes from './components/Estudiantes'; 




const client = new ApolloClient({
  uri: 'http://localhost:90/graphql',
  fetchOptions: {
    credentials: 'same-origin', 
  },
  onError: ({networkError, graphQLErrors}) => {
    console.log('graphQLErrors',graphQLErrors);
    console.log('networkError', networkError);
  }
});

class App extends Component {
  render(){
    return (
      
      <ApolloProvider client={client}>
       <h1>Test</h1>
       <Estudiantes/>
       
      </ApolloProvider>
    );
  }
}

export default App;
