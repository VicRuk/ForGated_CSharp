import { StyleSheet } from 'react-native';
import fonts from '../../styles/fonts';

export const styles = StyleSheet.create({
  container:{
    flex: 1,
    backgroundColor: "#407BFF",
    alignItems: 'center',
    paddingHorizontal: 40,
    justifyContent: 'center'
  },

  header:{
    flexDirection: 'row',
    marginTop: 30,
    justifyContent: 'center'
  },

  imagemTermometro:{
    width: 200,
    height: 455,
    transform: [{ rotateX: '180deg' }],
    left: 130,
    bottom: 150,
  },

  registro:{
    position: 'absolute',
    bottom: 0,
   left: 0,
    right: 0,
    borderTopLeftRadius: 25,
    borderTopRightRadius: 25,
    height: 80,
    backgroundColor: '#fff',
    alignItems: 'flex-start',
    justifyContent: 'center'
  },

  registroText:{
    fontWeight: 'bold',
    fontSize: 17,
    left: 15
  },

  bottomSheet:{
    backgroundColor: 'white',
    height: 75,
    position: 'absolute',
    borderTopRightRadius: 15,
    borderTopLeftRadius: 15,
    bottom: 0,
    right: 0,
    left: 0,
    justifyContent: 'center',
  },

  contentBottom:{
    backgroundColor: 'white',
    borderTopRightRadius: 20,
    borderTopLeftRadius: 20,
  },

  textBottom:{
    left: 22,
    fontWeight: 'bold',
    fontSize: 18,
  },

  textBottomContent:{
    left: 20,
    fontWeight: 'bold',
    fontSize: 16,
    marginTop: 10,
    marginBottom: 25,
  },

  sair:{
    left:0,
    right: 0,
    height: 30,
    top: 0,
    backgroundColor: 'transparent',
    justifyContent: 'center',
    alignItems: 'center',
    marginTop: 10,
  },

  sairMarca:{
    height: 7,
    width: 75,
    borderRadius: 10,
    backgroundColor: '#000',
  },

  voltar:{
    flexDirection: 'row',
    alignItems: 'center',
    position: 'absolute',
    top: 10,
    left: 25
  },

  alerta:{
    borderTopLeftRadius: 200,
    borderTopRightRadius: 200,
    top: 225,
    height: 465,
    backgroundColor: '#D41717',
    shadowColor: 'black',
    shadowOffset: {width: 0, height: 2},
    shadowOpacity: 0.4,
    shadowRadius: 4,
    elevation: 5,
  },

  alertaNot:{
    borderTopLeftRadius: 200,
    borderTopRightRadius: 200,
    top: 225,
    height: 540,
    backgroundColor: '#EDF1FC',
    shadowColor: 'black',
    shadowOffset: {width: 0, height: 2},
    shadowOpacity: 0.4,
    shadowRadius: 4,
    elevation: 5,
  },

  textb:{
    fontWeight: 'bold'
  },

  primaryTilt:{
    textAlign: 'center',
    fontWeight: 'bold',
    fontSize: 27,
    fontFamily: fonts.text,
  },

  secondaryTilt:{
    marginLeft: 40,
    fontSize: 15,
    fontFamily: fonts.text,
  },

primaryTilt:{
  marginTop: 15,
  textAlign: 'center',
  fontWeight: 'bold',
  fontSize: 23,
  fontFamily: fonts.text,
},

secondaryTilt:{
  marginLeft: 40,
  fontSize: 15,
  fontFamily: fonts.text,
},

imagemEletricidade:{
  width: 200,
  height: 450,
  left: -27,
  bottom: 20,
},

imagemEletricidade2:{
  width: 200,
  height: 510,
  left: -40,
  bottom: 40,
  shadowColor: 'black',
  shadowOffset: {width: 0, height: 2},
  shadowOpacity: 0.4,
  shadowRadius: 4,
  elevation: 5,
},

puxar:{
  height: 7,
  width: 75,
  borderRadius: 10,
  backgroundColor: '#D9D9D9',
  left: 160,
  marginBottom: 5
},
})


